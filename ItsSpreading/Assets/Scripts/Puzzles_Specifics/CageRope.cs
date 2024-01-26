using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageRope : Interactable
{

    [SerializeField] private GameObject handlerObj;
    [SerializeField] private GameObject cageObj;
    [SerializeField] private GameObject finalCagePosTag;
    [SerializeField] private GameObject dogObj;
    [SerializeField] private GameObject glitchedDoor;
    private float cageHalfWidth = 5f;
    private bool isCut = false;
    private bool isCageDown = false;
    private float dropSpeed = 0.3f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = cageObj.transform.position;
    }
    
    public void CutIt()
    {
        isCut = true;
        glitchedDoor.GetComponent<SpriteRenderer>().enabled = false;
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
                    gameObject.SetActive(false);
                    handlerObj.GetComponent<GameHandler>().CallDialogueByValue(43);
                }
            }
        }
    }

    public void ResetCage()
    {
        cageObj.transform.position = startPos;
        isCut = false;
        isCageDown = false;
        glitchedDoor.GetComponent<SpriteRenderer>().enabled = true;
    }
}
