using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatingMachine : Interactable
{
    [SerializeField] private GameObject expensiveMachine;
    public int money = 1;
    private int moneyNeeded = 100;

    private void Start()
    {
        base.Start();
        expensiveMachine.GetComponent<VendingMachine>().moneyNeeded = moneyNeeded;
    }

    public string InteractWithIt(int objectHeldID)
    {
        if (objectHeldID != 9) return "You need money to use this.";
        money *= 2;
        if (money >= moneyNeeded) expensiveMachine.GetComponent<VendingMachine>().canGiveItem = true;
        return ("The machine somehow doubled your money. You now have " + money + "$.");

       
    }
}
