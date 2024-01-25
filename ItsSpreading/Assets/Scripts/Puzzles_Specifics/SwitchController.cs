using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : Interactable
{
    [SerializeField] private GameObject dialogueToTurnOff;
    [SerializeField] private bool state;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject wallObj1;
    [SerializeField] private GameObject wallObj2;
    [SerializeField] private GameObject wallObj3;

    [SerializeField] private int behaviorID;

    [SerializeField] private GameObject otherSwitch1;
    [SerializeField] private GameObject otherSwitch2;
    [SerializeField] private GameObject doorLockedObj;

    private void Start()
    {
        base.Start();
        UpdateSpriteColor();
    }

    public void InteractWith()
    {
        state = !state;
        UpdateStateAndWall();
        UpdateSpriteColor();
        CheckIfRight();
    }

    private void UpdateStateAndWall()
    {
        if (behaviorID == 1)
        {
            wallObj1.GetComponent<BlockingWall>().SwitchState();
            wallObj3.GetComponent<BlockingWall>().SwitchState();
        }

        if (behaviorID == 2)
        {
            wallObj2.GetComponent<BlockingWall>().SetState(state);
            wallObj3.GetComponent<BlockingWall>().SwitchState();
        }

        if (behaviorID == 3)
        {
            wallObj1.GetComponent<BlockingWall>().SetState(state);
            wallObj3.GetComponent<BlockingWall>().SetState(state);
        }
        
        
    }

    private void UpdateSpriteColor()
    {
        if (state)
        {
            defaultColor = Color.green;
            _spriteRenderer.color = Color.green;
            return;
        }
        defaultColor = Color.red;
        _spriteRenderer.color = Color.red;
    }
    private void CheckIfRight()
    {
        if (wallObj1.GetComponent<BlockingWall>().GetState() && wallObj2.GetComponent<BlockingWall>().GetState() &&
            wallObj3.GetComponent<BlockingWall>().GetState())
        {
            otherSwitch1.GetComponent<SwitchController>().canInteract = false;
            otherSwitch2.GetComponent<SwitchController>().canInteract = false;
            canInteract = false;
            doorLockedObj.SetActive(true);
            if(dialogueToTurnOff != null) Destroy(dialogueToTurnOff);
        }
    }
    


}
