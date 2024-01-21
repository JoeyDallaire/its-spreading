using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private GameObject handlerObj;
    private bool facingRight = true;
    public bool canMove = true;
    public bool isHiding;

    [SerializeField] private Sprite test_face;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
    }

    public void setCameraPos()
    {
        cameraObj.GetComponent<CameraControl>().UpdateCamera(transform
            .position);
    }

    public void DieFromDog()
    {
        handlerObj.GetComponent<GameHandler>().GameOver();
    }

    public void HidePlayer(bool hiding)
    {
        canMove = !hiding;
        gameObject.GetComponent<SpriteRenderer>().enabled = !hiding;
    }
    
    private void UpdateInputs()
    {
        // Player movement
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveThis(movementSpeed);
                _animator.SetBool("isWalking",true);
                setCameraPos();
            }
                    
            else if (Input.GetKey(KeyCode.A))
            {
                MoveThis(movementSpeed * -1);
                _animator.SetBool("isWalking",true);
                setCameraPos();
            }
            
            else _animator.SetBool("isWalking", false);
        }
        // Interact Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handlerObj.GetComponent<GameHandler>().InteractButtonPress();
        }
        
        // Testing 
        if (Input.GetKeyDown(KeyCode.E))
        {
            handlerObj.GetComponent<GameHandler>().LoadNextLevel();
        }
    }
}
