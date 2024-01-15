using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string actionName;
    [SerializeField] private int actionID;
    
    // 1 = open door;
    
    public string GetAcionName()
    {
        return actionName;
    }

    public int GetActionID()
    {
        return actionID;
    }
    

}
