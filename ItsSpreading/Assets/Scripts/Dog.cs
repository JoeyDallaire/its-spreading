using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Entity
{
    // Following related
    [SerializeField] private GameObject playerObj;
    private const float MAX_DIST_FROM_PLAYER = 3f;
    private const float SPEED_MULTIPLIER = 0.03f;
    private const float HOSTILE_SPEED_MULTIPLIER = 0.015f;
    private const float X_POS_TO_ATTACK = -1.8f;
    private const int HOSTILE_NEW_ROOM_WAIT_TIME = 4;
    
    // State related
    public bool exists = true;
    private bool isHostile = false;
    
    private const int FOLLOW_UNTIL = 7;
    private const int EXIST_UNTIL = 9;

    [HideInInspector] public int currentState = 0;
    [SerializeField] private Sprite hostileSprite;
    
    

    void Update()
    {
        if(currentState < FOLLOW_UNTIL) FollowPlayer();
        else if(currentState < EXIST_UNTIL) HostileState();
    }


    private void FollowPlayer()
    {
        if (Math.Abs(playerObj.transform.position.x - transform.position.x) > MAX_DIST_FROM_PLAYER)
        {
            MoveThis((playerObj.transform.position.x - transform.position.x)*SPEED_MULTIPLIER);
        }
    }

    private void HostileState()
    {
        if(playerObj.transform.position.x < X_POS_TO_ATTACK && !isHostile) return;
        if (isHostile)
        {
            if (Math.Abs(playerObj.transform.position.x - transform.position.x) > MAX_DIST_FROM_PLAYER)
            {
                MoveThis((playerObj.transform.position.x - transform.position.x)*SPEED_MULTIPLIER);
                return;
            }
            else playerObj.GetComponent<PlayerController>().DieFromDog();
            return;
        }
        // This code will only be reached when the dog STARTS to become hostile
        Debug.Log("The dog is getting angy");
        SetNewSprite();
        isHostile = true;
    }


    public void LoadingInNewRoom(Vector3 newPosition)
    {
        if (!exists)
        {
            gameObject.SetActive(false);
            return;
        }

        if (isHostile) ChangePositionCoroutine(newPosition, HOSTILE_NEW_ROOM_WAIT_TIME);
        else transform.position = newPosition;//ChangePositionCoroutine(newPosition, 0);

    }

    private void SetNewSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hostileSprite;
    }

    IEnumerator ChangePositionCoroutine(Vector3 newPosition, int waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        transform.position = newPosition;
    }
    
    
    
}
