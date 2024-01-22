using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsCutscene : MonoBehaviour
{
    [SerializeField] private GameObject finalPosTag;
    [SerializeField] private Sprite glitchedSprite;
    [SerializeField] private int speed;
    
    private Vector3 finalPosition;
    private int ticker;

    private void Start()
    {
        finalPosition = finalPosTag.transform.position;
        
    }

    private void Update()
    {
        
    }
}
