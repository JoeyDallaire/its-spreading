using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canInteract = true;
    
    [SerializeField] private string actionName;
    [SerializeField] private int actionID;
    [SerializeField] private int contextID;

    [SerializeField] private int objectNeededID; // 0 = no object needed
    
    // 1 = open door
    // 2 = take item
    // 3 = use box on stack of boxes
    
    public string GetAcionName()
    {
        return actionName;
    }

    public int GetActionID()
    {
        return actionID;
    }

    public int GetContextID()
    {
        return contextID;
    }

    public int GetObjectNeededID()
    {
        return objectNeededID;
    }

    public void DeleteThisObj()
    {
        gameObject.SetActive(false);
    }

    public virtual void UseObjectOnIt(int objectID)
    {
        
    }
}
