using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingWall : MonoBehaviour
{
    private bool state;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        UpdateSpriteColor();
    }

    private void UpdateBlockObj()
    {
        
    }

    public void SwitchState()
    {
        state = !state;
        UpdateSpriteColor();
    }

    public void SetState(bool newState)
    {
        state = newState;
        UpdateSpriteColor();
    }
    
    private void UpdateSpriteColor()
    {
        if (state)
        {
            _spriteRenderer.color = Color.green;
            return;
        }
        _spriteRenderer.color = Color.red;
    }

    public bool GetState()
    {
        return state;
    }


}
