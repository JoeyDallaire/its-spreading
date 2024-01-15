using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private GameObject handlerObj;
    private bool facingRight = true;
    public bool canMove = true;

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
    
    private void UpdateInputs()
    {
        // Player movement
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveThis(movementSpeed);
                setCameraPos();
            }
                    
            if (Input.GetKey(KeyCode.A))
            {
                MoveThis(movementSpeed * -1);
                setCameraPos();
            }
        }
        // Interact Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handlerObj.GetComponent<GameHandler>().InteractButtonPress();
        }
        
        // Testing 
        if (Input.GetKeyDown(KeyCode.E))
        {
            handlerObj.GetComponent<GameHandler>().CallDialogue("pp pp pp pp pp pp pp pp pp", test_face);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlerObj.GetComponent<GameHandler>().LoadNewRoom(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlerObj.GetComponent<GameHandler>().LoadNewRoom(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlerObj.GetComponent<GameHandler>().LoadNewRoom(3);
        }
    }
}
