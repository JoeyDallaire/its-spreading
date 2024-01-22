using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // highlight stuff
    private SpriteRenderer objectSprite;
    private bool hasSprite  = true;
    private Color highlightColor = new Color(0.745f, 1, 1);
    private Color defaultColor = Color.white;
    
    public bool canInteract = true;

    [SerializeField] private Vector3 posToMove; 
    
    
    [SerializeField] private string actionName;
    [SerializeField] private int actionID;
    [SerializeField] private int contextID;
    [SerializeField] private bool isATrigger;
    [SerializeField] private GameObject objectToInitiate;
    public Sprite heldObjectSprite;

    [SerializeField] private int objectNeededID; // 0 = no object needed
    
    // 1 = open door
    // 2 = take item
    // 3 = use box on stack of boxes
    // 4 = open door backwards
    // 5 = hide...
    // 6 = cut thing with scissor :)
    // 7 = start demo cutscene
    // 8 = throw ball
    // 9 = unlock locker locks

    public void Start()
    {
        if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            objectSprite = spriteRenderer;
            return;
        }

        hasSprite = false;
    }


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

    public bool IsTrigger()
    {
        return isATrigger;
    }

    public void SetHighlight(bool highlighted)
    {
        if(!hasSprite) return;
        if (highlighted)
        {
            objectSprite.color = highlightColor;
            return;
        }

        objectSprite.color = defaultColor;
    }

    public void MoveThis()
    {
        //TODO MAKE IT AN ANIMATION
        gameObject.transform.position = posToMove;
    }

    public void ChangeAction(int newActionID, String newActionName)
    {
        actionID = newActionID;
        actionName = newActionName;
    }

    public void InitiateNewObj()
    {
        objectToInitiate.SetActive(true);
    }
}
