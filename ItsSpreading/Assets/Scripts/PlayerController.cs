﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private GameObject handlerObj;
    [SerializeField] private AudioSource _audioSource;
    private bool facingRight = true;
    public bool canMove = true;
    public bool isHiding;
    [HideInInspector] public bool forceStop = false ; 

    private Sprite objectHeldImage;

    [SerializeField] private GameObject heldObjectObj;
    [SerializeField] private GameObject heldObjectLeftTag;
    [SerializeField] private GameObject heldObjectObjRightTag;

    [SerializeField] private Sprite test_face;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!forceStop) UpdateMovementInputs();
    }

    private void Update()
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

    public void HoldingChange(bool isHolding)
    {
        // This should always be given the false parameter!
        _animator.SetBool("Holding", isHolding);
        heldObjectObj.SetActive(false);
        
    }

    public void HoldingChange(bool isHolding, Sprite objSprite)
    {
        // This should always be given the true parameter!
        _animator.SetBool("Holding", isHolding);
        heldObjectObj.SetActive(true);
        heldObjectObj.GetComponent<SpriteRenderer>().sprite = objSprite;

    }

    private void UpdateHeldObjectPOS()
    {
        if (isLookingLeft)
        {
            heldObjectObj.transform.position = heldObjectLeftTag.transform.position;
            return;
        }
        heldObjectObj.transform.position = heldObjectObjRightTag.transform.position;
        
    }

    private void UpdateMovementInputs()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveThis(movementSpeed);
                _animator.SetBool("Walking",true);
                _audioSource.mute = false;
                setCameraPos();
                UpdateHeldObjectPOS();
            }
                    
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveThis(movementSpeed * -1);
                _animator.SetBool("Walking",true);
                _audioSource.mute = false;
                setCameraPos();
                UpdateHeldObjectPOS();
            }

            else
            {
                _animator.SetBool("Walking", false);
                _audioSource.mute = true;
            }

            
        } else _animator.SetBool("Walking", false);
    }

    public void StopAll()
    {
        _animator.SetBool("Walking", false);
        _audioSource.Stop();
        _audioSource.mute = true;
        _audioSource.Play();
        canMove = false;
    }
    private void UpdateInputs()
    {
        
        // Interact Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handlerObj.GetComponent<GameHandler>().InteractButtonPress();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            handlerObj.GetComponent<GameHandler>().LoadNextLevel();
        }*/
    }
}
