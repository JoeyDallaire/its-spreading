using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private bool isLookingLeft;
    
    // Following related
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject gameHandlerObj;
    private const float MAX_DIST_FROM_PLAYER = 3f;
    private const float SPEED_MULTIPLIER = 0.05f;
    private const float HOSTILE_SPEED_VALUE = 0.1f;
    private const float X_POS_TO_ATTACK = -1.8f;
    private const float HOSTILE_DIST_FROM_DOOR = 2f;
    
    
    [SerializeField] private GameObject cafetEndTag;
    [SerializeField] private GameObject couloirStartTag;
    [SerializeField] private GameObject couloirEndTag;
    [SerializeField] private GameObject gymStartTag;

    [SerializeField] private GameObject wallToDestroy;
    
    // State related
    public bool exists = true;
    private bool isHostile = false;
    [HideInInspector] public bool isBlockedInCage = false;
    
    private const int FOLLOW_UNTIL = 7;
    private const int HOSTILE_AT = 9;

    public int currentState = 0;
    private bool stopLoadingInNewRoom = false;
    [SerializeField] private Sprite hostileSprite;

    private Vector3 lastLoadingPosition;
    
    // Animation related
    [SerializeField] private Animator _animator;
    private int buggedLevel = 0;
    private bool isWalking = false;

    public void Start()
    {
        _animator.SetInteger("glitchedLvl", 0);
    }

    void FixedUpdate()
    {
        if(isBlockedInCage) return;
        if (currentState < FOLLOW_UNTIL)
        {
            FollowPlayer();
            return;
        };
        if (currentState == 7) stopLoadingInNewRoom = true;
        if(currentState >= HOSTILE_AT) HostileState();
        _animator.SetBool("isWalking", true);
    }


    private void FollowPlayer()
    {
        if (Math.Abs(playerObj.transform.position.x - transform.position.x) > MAX_DIST_FROM_PLAYER)
        {
            _animator.SetBool("isWalking", true);
            MoveThis((playerObj.transform.position.x - transform.position.x)*SPEED_MULTIPLIER);
            return;
        }
        _animator.SetBool("isWalking", false);
    }

    private void HostileState()
    {
        if(playerObj.transform.position.x < X_POS_TO_ATTACK && !isHostile) return;
        if (isHostile)
        {
            // close to door handling
            if (Math.Abs(cafetEndTag.transform.position.x - transform.position.x) <= HOSTILE_DIST_FROM_DOOR)
            {
                transform.position = new Vector3(couloirStartTag.transform.position.x, transform.position.y,
                    transform.position.z);
            }
            if (Math.Abs(couloirEndTag.transform.position.x - transform.position.x) <= HOSTILE_DIST_FROM_DOOR)
            {
                transform.position = new Vector3(gymStartTag.transform.position.x, transform.position.y,
                    transform.position.z);
            }
            // close to wall to destroy handler
            if (Math.Abs(wallToDestroy.transform.position.x - transform.position.x) <= HOSTILE_DIST_FROM_DOOR)
            {
                wallToDestroy.GetComponent<WallOfDeath>().DestroyWall();
            }
            // normal chase
            MoveThis(GetDogChaseSpeed());
            if (Math.Abs(playerObj.transform.position.x - transform.position.x) <= MAX_DIST_FROM_PLAYER && !gameHandlerObj.GetComponent<GameHandler>().isHiding)
            {
                playerObj.GetComponent<PlayerController>().DieFromDog();
            }
            return;
        }
        // This code will only be reached when the dog STARTS to become hostile
        isHostile = true;
    }


    public void LoadingInNewRoom(Vector3 newPosition)
    {
        if (!exists)
        {
            gameObject.SetActive(false);
        }

        if (isHostile || stopLoadingInNewRoom)
        {
            return;
        }
        transform.position = newPosition;
        lastLoadingPosition = newPosition;

    }

    public void ResetValuesAtGameOver()
    {
        isHostile = false;
        transform.position = lastLoadingPosition;
    }
    
    public void MoveThis(float direction)
    {
        float nextPos = gameObject.transform.position.x + direction;
        gameObject.transform.position += new Vector3(direction,0,0);
        gameObject.GetComponent<SpriteRenderer>().flipX = (direction > 0f);
        isLookingLeft = (direction > 0f);
    }

    private float GetDogChaseSpeed()
    {
        if (currentState == 9) return HOSTILE_SPEED_VALUE;
        if (currentState == 10) return HOSTILE_SPEED_VALUE * 1.1f;
        if (currentState == 11) return HOSTILE_SPEED_VALUE * 1.3f;
        return HOSTILE_SPEED_VALUE * 1.5f;
    }

    
}
