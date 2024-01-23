using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class VisualGlitch : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private bool isFlipping = false;
    private bool isFlipped;
    [SerializeField] private bool isRotating = false;
    [SerializeField] private bool isTwitching = false;
    [SerializeField] private Vector3 twitchDistance;
    [SerializeField] private bool isSwitchingOff = false;
    [SerializeField] private float actionSpeed;
    [SerializeField] private float undoActionSpeed;


    private float ticker;
    private bool actionDone;
    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ticker += Time.deltaTime;
        if (ticker >= actionSpeed && actionDone == false)
        {
            if (isFlipping) Flip();
            if (isRotating) Rotate(false);
            if (isTwitching) Twitch(false);
            if (isSwitchingOff) SwitchOff(false);
            actionDone = true;
            return;
        }

        if (ticker >= (actionSpeed + undoActionSpeed) && actionDone)
        {
            if (isFlipping) Flip();
            if (isRotating) Rotate(true);
            if (isTwitching) Twitch(true);
            if (isSwitchingOff) SwitchOff(true);
            actionDone = false;
            ticker = 0f;
        }
        
    }

    private void Flip()
    {
        _spriteRenderer.flipX = !isFlipped;
        isFlipped = !isFlipped;
    }

    private void Rotate(bool undo)
    {
        if (undo)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            return;
        }
        transform.Rotate(new Vector3(0, 0, 90));
    }

    private void Twitch(bool undo)
    {
        if (undo)
        {
            transform.position -= twitchDistance;
            return;
        }
        transform.position += twitchDistance;
    }

    private void SwitchOff(bool undo)
    {
        _spriteRenderer.enabled = !undo;
    }
    
}
