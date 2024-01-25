using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackOfBoxes : Interactable
{
    [SerializeField] private GameObject box1Obj;
    [SerializeField] private GameObject box2Obj;
    [SerializeField] private GameObject box3Obj;

    [SerializeField] private GameObject fullStackObj;

    [SerializeField] private GameObject handlerObj;
    
    private int nbOfBoxes = 0;


    public void UseObjectOnIt()
    {
        if(nbOfBoxes == 0) box1Obj.SetActive(true);
        else if (nbOfBoxes == 1 ) box2Obj.SetActive(true);
        else if (nbOfBoxes == 2) box3Obj.SetActive(true);
        nbOfBoxes++;

        if (nbOfBoxes == 3)
        {
            
            fullStackObj.SetActive(true);
            canInteract = false;
            handlerObj.GetComponent<GameHandler>().CallDialogueByValue(9);
        }
    }
}
