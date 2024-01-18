using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler: MonoBehaviour
{
    private const float MAX_DIST_FROM_INTERACTABLE = 1f;
    private const float PLAYER_Y_POSITION = -1.25f;
    private const float PLAYER_Z_POSITION = 0f;
    private const float DOG_Y_POSITION = -0.5f;
    private const float DOG_Z_POSITION = 2f;
    
    //[SerializeField] private float initialMaxRightPos;
    //private float _maxRightPosition;
    
    

    [SerializeField] private GameObject dialogueBoxObj;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private GameObject dogObj;
    [SerializeField] private GameObject nextLevelScreenObj;
    private GameObject proximityObj;
    
    
    [SerializeField] private List<Entity> entities = new List<Entity>();
    [SerializeField] private List<GameObject> interactableObjs = new List<GameObject>();

    // Story/Room/State IDs; 0 is used for debugging or for start screen.
    public int currentRoomID = 1;
    public int currentStateID = 1;
    public int currentStoryStateID = 1;
    
    
    // Player related
    private bool isInDialogue = false;
    private bool isInNextLevelScreen = false;
    private int heldObject = 0;
    
    public void Start()
    {
        LoadNewRoom(currentRoomID, true);
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
                (transform.position.x - obj.transform.position.x) >= -MAX_DIST_FROM_INTERACTABLE &&
                obj.GetComponent<Interactable>().canInteract)
            {
                proximityObj = obj;
                return;
            }
        }

        proximityObj = null;
        
        
    }

    public void InteractButtonPress()
    {
        if (isInDialogue)
        {
            DeleteCurrentDialogue();
            return;
        }
        
        if (isInNextLevelScreen)
        {
            nextLevelScreenObj.GetComponent<NewLevelScreen>().DeleteScreen();
            isInNextLevelScreen = false;
            playerObj.GetComponent<PlayerController>().canMove = true;
            return;
        }
        if (proximityObj != null)
        {
            InteractWithObj();
            return;
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

    public void LoadNewRoom(int newRoomID, bool comingLeft)
    {
        float newXpos = gameObject.GetComponent<TagHandler>().GetPlayerPosNewRoom(newRoomID, comingLeft);
        
        
        playerObj.transform.position = new Vector3(newXpos,PLAYER_Y_POSITION, PLAYER_Z_POSITION);
        dogObj.GetComponent<Dog>().LoadingInNewRoom(new Vector3(newXpos,DOG_Y_POSITION,DOG_Z_POSITION));
        SetMaxPos(newRoomID);
        playerObj.GetComponent<PlayerController>().setCameraPos();
        currentRoomID = newRoomID;
    }

    private void LoadNextLevel()
    {
        LoadNewRoom(1, true);
        gameObject.GetComponent<LevelLoader>().UpdatLevelObjects(currentStateID,false);
        currentStateID++;
        gameObject.GetComponent<LevelLoader>().UpdatLevelObjects(currentStateID,true);
        nextLevelScreenObj.GetComponent<NewLevelScreen>().LoadScreen(currentStateID, 3);
                    // TODO : make array to change the lives value depending on story needs ^^^
        isInNextLevelScreen = true;
        playerObj.GetComponent<PlayerController>().canMove = false;
    }

    private void InteractWithObj()
    {
        int checkObjectNeeded = proximityObj.GetComponent<Interactable>().GetObjectNeededID();

        if (checkObjectNeeded == 0 || checkObjectNeeded == heldObject)
        {
            switch (proximityObj.GetComponent<Interactable>().GetActionID())
            {
                case 1: // Open Door
                {
                    if (currentRoomID == 3) LoadNextLevel();
                    else LoadNewRoom(currentRoomID + 1, true);
                }
                    break;
                case 2: // Take Object
                {
                    if (heldObject == 0)
                    {
                        heldObject = proximityObj.GetComponent<Interactable>().GetContextID();
                        proximityObj.GetComponent<Interactable>().DeleteThisObj();
                        Debug.Log("Now holding object ID : " + heldObject);
                    }

                    break;
                }
                case 3: // Use box on stacks of boxes
                {
                    if (heldObject == 1)
                    {
                        heldObject = 0;
                        proximityObj.GetComponent<StackOfBoxes>().UseObjectOnIt();
                    }
                    break;
                }

                case 4: // Open door backward
                {
                    LoadNewRoom(currentRoomID -1, false);
                }
                    break;
            }
        }
    }
}
