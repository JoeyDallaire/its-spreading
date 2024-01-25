using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : Interactable
{
    [SerializeField] private GameObject gameHandlerObj;
    [SerializeField] private GameObject keySpriteObj;
    
    public bool canGiveItem;
    public int moneyNeeded;

    public int InteractWithIt(int objectHeldID)
    {
        if (objectHeldID != 9) return 43;
        if (canGiveItem)
        {
            canInteract = false;
            gameHandlerObj.GetComponent<GameHandler>().RemoveHeldObject();
            InitiateNewObj(false);
            keySpriteObj.SetActive(false);
            gameObject.GetComponent<AudioSource>().Play();
            return 33;
        }

        return 43;
    }

}
