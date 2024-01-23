using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScissorsCutscene : MonoBehaviour
{
    [SerializeField] private Sprite glitchedSprite;
    [SerializeField] private Sprite scissorsSprite;
    [SerializeField] private int lenght;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Vector3 scissorsScale;
    [SerializeField] private Vector3 glitchScale;
    
    
    private int ticker = 0;

    private void Start()
    {
        _spriteRenderer.sprite = glitchedSprite;
        transform.localScale = glitchScale;
    }

    private void Update()
    {
        ticker++;
        if (ticker > lenght)
        {
            _spriteRenderer.sprite = glitchedSprite;
            transform.localScale = glitchScale;
            ticker = 0;
            return;
        }
        
        if (ticker > lenght/4)
        {
            _spriteRenderer.sprite = scissorsSprite;
            transform.localScale = scissorsScale;
            return;
        }
    }
    
    
}
