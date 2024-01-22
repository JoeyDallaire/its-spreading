using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerLocks : Interactable
{
    [SerializeField] private GameObject lockObj1;
    [SerializeField] private GameObject lockObj2;
    [SerializeField] private GameObject lockObj3;

    [SerializeField] private GameObject openLockerObj;
    private int locksLeft = 3;

    public void UseKeyOnIt()
    {
        locksLeft--;
        if (locksLeft == 2)
        {
            lockObj1.SetActive(false);
            return;
        }
        if (locksLeft == 1)
        {
            lockObj2.SetActive(false);
            return;
        }
        if (locksLeft == 0)
        {
            lockObj3.SetActive(false);
            openLockerObj.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
}
