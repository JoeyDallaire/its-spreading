using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : Interactable
{
    [SerializeField] private GameObject gameHandlerObj;
    
    public bool canGiveItem;
    public int moneyNeeded;

    public String InteractWithIt(int objectHeldID)
    {
        if (objectHeldID != 9) return "You need money to use this.";
        if (canGiveItem)
        {
            InitiateNewObj();
            canInteract = false;
            gameHandlerObj.GetComponent<GameHandler>().RemoveHeldObject();
            InitiateNewObj();
            return "A key comes out of the machine!";
        }

        return "You need " + moneyNeeded + "$ for this one.";
    }

}
