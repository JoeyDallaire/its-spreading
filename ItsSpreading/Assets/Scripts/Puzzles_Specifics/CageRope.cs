﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageRope : Interactable
{
    
    
    [SerializeField] private GameObject cageObj;
    [SerializeField] private GameObject finalCagePosTag;
    [SerializeField] private GameObject dogObj;
    [SerializeField] private GameObject glitchedDoor;
    private float cageHalfWidth = 5f;
    private bool isCut = false;
    private bool isCageDown = false;
    private float dropSpeed = 0.3f;
    
    public void CutIt()
    {
        isCut = true;
    }

    public void Update()
    {
        if (isCut && !isCageDown)
        {
            cageObj.transform.position -= new Vector3(0f, dropSpeed, 0);
            if (cageObj.transform.position.y <= finalCagePosTag.transform.position.y)
            {
                isCageDown = true;
                if (Mathf.Abs(dogObj.transform.position.x - cageObj.transform.position.x) < cageHalfWidth)
                {
                    dogObj.GetComponent<Dog>().isBlockedInCage = true;
                    dogObj.GetComponent<Dog>().exists = false;
                    glitchedDoor.SetActive(true);
                }
            }
        }
    }
}