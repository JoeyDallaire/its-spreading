using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    [SerializeField] private GameObject cameraObj;
    private bool facingRight = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
    }

    private void setCameraPos()
    {
        cameraObj.GetComponent<CameraControl>().UpdateCamera(transform
            .position);
    }
    
    private void UpdateInputs()
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
}
