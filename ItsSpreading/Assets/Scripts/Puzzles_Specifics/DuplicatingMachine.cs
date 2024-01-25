using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatingMachine : Interactable
{
    [SerializeField] private GameObject expensiveMachine;
    public int money = 1;
    private int moneyNeeded = 6;

    private void Start()
    {
        base.Start();
        expensiveMachine.GetComponent<VendingMachine>().moneyNeeded = moneyNeeded;
    }

    public int InteractWithIt(int objectHeldID)
    {
        if (objectHeldID != 9) return 40;
        money *= 2;
        if (money >= moneyNeeded) expensiveMachine.GetComponent<VendingMachine>().canGiveItem = true;
        gameObject.GetComponent<AudioSource>().Play();
        return 33;


    }
}
