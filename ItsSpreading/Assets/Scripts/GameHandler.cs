using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler: MonoBehaviour
{
    private const float MAX_DIST_FROM_INTERACTABLE = 1f;
    private const float PLAYER_Y_POSITION = -1.25f;
    private const float PLAYER_Z_POSITION = 0f;
    
    //[SerializeField] private float initialMaxRightPos;
    //private float _maxRightPosition;
    
    [SerializeField] private List<Entity> entities = new List<Entity>();

    [SerializeField] private GameObject dialogueBoxObj;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject cameraObj;
    
    private GameObject proximityObj;
    [SerializeField] private List<GameObject> interactableObjs = new List<GameObject>();

    // Story/Room/State IDs; 0 is used for debugging or for start screen.
    public int currentRoomID = 1;
    public int currentStateID = 1;
    public int currentStoryStateID = 1;
    
    private bool isInDialogue = true;
    
    
    public void Start()
    {
        LoadNewRoom(currentRoomID);
    }

    public void Update()
    {
        UpdateProximityObj();
    }

    public void SetMaxPos(int roomID)
    {
        float newMaxLeftPos = gameObject.GetComponent<TagHandler>().GetMaxPos(true, roomID);
        float newMaxRightPos = gameObject.GetComponent<TagHandler>().GetMaxPos(false, roomID);
        foreach (var entity in  entities)
        {
            entity.SetMaxRightPos(newMaxRightPos);
            entity.SetMaxLeftPos(newMaxLeftPos);
        }
        
        cameraObj.GetComponent<CameraControl>().UpdateMaxPos(newMaxLeftPos + 9.5f, newMaxRightPos-9.5f);
    }

    private void UpdateProximityObj()
    {
        foreach (GameObject obj in interactableObjs)
        {
            
            
            if ((transform.position.x - obj.transform.position.x) <= MAX_DIST_FROM_INTERACTABLE &&
                (transform.position.x - obj.transform.position.x) >= -MAX_DIST_FROM_INTERACTABLE)
            {
                proximityObj = obj;
                return;
            }
        }

        proximityObj = null;
        
        
    }

    public void InteractButtonPress()
    {
        if(isInDialogue) DeleteCurrentDialogue();
        else if (proximityObj != null)
        {
            InteractWithObj();
        }
    }

    public void CallDialogue(string text, Sprite faceImg)
    {
        dialogueBoxObj.GetComponent<DialogueBox>().callDialogueBox(text,faceImg);
        playerObj.GetComponent<PlayerController>().canMove = false;
        isInDialogue = true;
    }

    private void DeleteCurrentDialogue()
    {
        dialogueBoxObj.GetComponent<DialogueBox>().DeleteCurrentDialogueBox();
        isInDialogue = false;
        playerObj.GetComponent<PlayerController>().canMove = true;
    }

    public void LoadNewRoom(int newRoomID)
    {
        playerObj.transform.position = new Vector3(gameObject.GetComponent<TagHandler>().GetPlayerPosNewRoom(newRoomID),
            PLAYER_Y_POSITION, PLAYER_Z_POSITION);
        SetMaxPos(newRoomID);
        playerObj.GetComponent<PlayerController>().setCameraPos();
        currentRoomID = newRoomID;
    }

    private void LoadNextLevel()
    {
        LoadNewRoom(1);
        currentStateID++;
        Debug.Log("Current level : " + currentStateID);
    }

    private void InteractWithObj()
    {
        switch (proximityObj.GetComponent<Interactable>().GetActionID())
        {
            case 1: // Open Door
            {
                if (currentRoomID==3) LoadNextLevel();
                else LoadNewRoom(currentRoomID+1);
            }
                break;
        }
    }
}
