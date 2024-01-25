﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using Object = System.Object;

public class GameHandler: MonoBehaviour
{
    private const float MAX_DIST_FROM_INTERACTABLE = 2.5f;
    private const float PLAYER_Y_POSITION = 0.96f;
    private const float PLAYER_Z_POSITION = 0f;
    private const float DOG_Y_POSITION = 2.89f;
    private const float DOG_Z_POSITION = 2f;
    
    //[SerializeField] private float initialMaxRightPos;
    //private float _maxRightPosition;
    
    

    [SerializeField] private GameObject dialogueBoxObj;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private GameObject dogObj;
    [SerializeField] private GameObject nextLevelScreenObj;
    [SerializeField] private GameObject proximityObj;
    private GameObject lastProximityObj;
    
    
    [SerializeField] private List<Entity> entities = new List<Entity>();
    [SerializeField] private List<GameObject> interactableObjs = new List<GameObject>();

    // Story/Room/State IDs; 0 is used for debugging or for start screen.
    public int currentRoomID = 1;
    public int currentStateID = 1;
    public int currentStoryStateID = 1;
    private int livesValue = 3;
    
    // Player related
    private bool isInDialogue = false;
    private bool isInNextLevelScreen = true;
    private int heldObject = 0;
    public bool isHiding = false;
    
    // UI
    private UIHandler _uiHandler;
    private float transitionScreenTicker = 0;
    private float transitionScreenTime = 0;
    private bool isInTransition = false;

    [SerializeField] private Sprite playerFaceSprite;
    [SerializeField] private Sprite dogFaceSprite;
    
    
    // datas
    private string dbFilename;
    private List<Dialogue> _dialogues = new List<Dialogue>(60);
    private List<Sprite> _dialogueSprites = new List<Sprite>(6);
    // Sounds
    [SerializeField] private AudioHandler audioHandler;
    [SerializeField] private AudioClip[] _LevelSoundClips;
    public void Start()
    {
        dbFilename = "URI=file:"+ Path.Combine(Application.streamingAssetsPath , "dialoguesData.db"); 
        _dialogues = LoadDialogue();
        _dialogueSprites = new List<Sprite>();
        _dialogueSprites.Add(playerFaceSprite);
        _dialogueSprites.Add(dogFaceSprite);
        LoadNewRoom(currentRoomID, true);
        nextLevelScreenObj.GetComponent<NewLevelScreen>().LoadScreen(currentStateID, 3);
        _uiHandler = gameObject.GetComponent<UIHandler>();
    }

    public void Update()
    {
        UpdateProximityObj();
        if(isInTransition) TransitionScreenLoop();
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
        
        cameraObj.GetComponent<CameraControl>().UpdateMaxPos(newMaxLeftPos + 10f, newMaxRightPos-9.5f);
    }

    private List<Dialogue> LoadDialogue()
    {
        List<Dialogue> tempDialogueList = new List<Dialogue>();
        using (var connection = new SqliteConnection(dbFilename))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                //command.CommandText = "CREATE TABLE IF NOT EXISTS dialogues (text VARCHAR(200), spriteid INT)";
                //command.ExecuteNonQuery();
                command.CommandText = "SELECT * FROM dialogues;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempDialogueList.Add(new Dialogue(reader["text"].ToString(), (int)reader["spriteid"]));
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }

        return tempDialogueList;
    }

    private void UpdateProximityObj()
    {
        foreach (GameObject obj in interactableObjs)
        {
            
            
            if ((transform.position.x - obj.transform.position.x) <= MAX_DIST_FROM_INTERACTABLE &&
                (transform.position.x - obj.transform.position.x) >= -MAX_DIST_FROM_INTERACTABLE &&
                obj.activeInHierarchy &&
                obj.GetComponent<Interactable>().canInteract)
            {
                if (obj.GetComponent<Interactable>().IsTrigger())
                {
                    proximityObj = obj;
                    InteractWithObj();
                }
                //_uiHandler.UpdateInteractableText(obj.GetComponent<Interactable>().GetAcionName());
                if(lastProximityObj != null && lastProximityObj != obj) lastProximityObj.GetComponent<Interactable>().SetHighlight(false);
                if (proximityObj == obj)
                {
                    lastProximityObj = obj;
                    return;
                }
                proximityObj = obj;
                obj.GetComponent<Interactable>().SetHighlight(true);
                return;
            }
        }

        if (proximityObj != null)
        {
            proximityObj.GetComponent<Interactable>().SetHighlight(false);
            proximityObj = null;
        }


    }

    public void PlaySound(int ID)
    {
        audioHandler.PlaySound(ID);
    }

    public void PlaySound(AudioClip sound)
    {
        audioHandler.PlaySound(sound);
    }

    public void InteractButtonPress()
    {
        if(isInTransition) return;
        if (isInNextLevelScreen)
        {
            nextLevelScreenObj.GetComponent<NewLevelScreen>().DeleteScreen();
            isInNextLevelScreen = false;
            playerObj.GetComponent<PlayerController>().canMove = true;
            return;
        }
        if (isInDialogue)
        {
            DeleteCurrentDialogue();
            return;
        }
        
        
        if (isHiding)
        {
            PlaySound(3);
            playerObj.GetComponent<PlayerController>().HidePlayer(false);
            isHiding = false;
            return;
        }
        if (proximityObj != null)
        {
            InteractWithObj();
            return;
        }

        
    }

    public void CallTransitionScreen(int SoundID, float transitionTime)
    {
        _uiHandler.SetTransitionScreen(true);
        isInTransition = true;
        transitionScreenTime = transitionTime;
        transitionScreenTicker = 0f;
        playerObj.GetComponent<PlayerController>().canMove = false;
        PlaySound(SoundID);
    }

    private void TransitionScreenLoop()
    {
        transitionScreenTicker += Time.deltaTime;
        if (transitionScreenTicker >= transitionScreenTime)
        {
            _uiHandler.SetTransitionScreen(false);
            isInTransition = false;
            playerObj.GetComponent<PlayerController>().canMove = true;
        }
    }

    public void CallDialogue(string text, Sprite faceImg)
    {
        dialogueBoxObj.GetComponent<DialogueBox>().callDialogueBox(text,faceImg);
        playerObj.GetComponent<PlayerController>().StopAll();
        isInDialogue = true;
    }

    public void CallDialogueByValue(int ID)
    {
        //CallDialogue(_dialogues[ID].getText(), _dialogueSprites[_dialogues[ID].getSpriteID()]);
        Dialogue tempDiag = _dialogues[ID];
        Sprite tempSprite = _dialogueSprites[tempDiag.getSpriteID()-1];
        CallDialogue(tempDiag.getText(), tempSprite);
    }

    private void DeleteCurrentDialogue()
    {
        dialogueBoxObj.GetComponent<DialogueBox>().DeleteCurrentDialogueBox();
        isInDialogue = false;
        playerObj.GetComponent<PlayerController>().canMove = true;
    }

    public void LoadNewRoom(int newRoomID, bool comingLeft)
    {
        playerObj.GetComponent<PlayerController>().canMove = false;
        float newXpos = gameObject.GetComponent<TagHandler>().GetPlayerPosNewRoom(newRoomID, comingLeft);
        playerObj.transform.position = new Vector3(newXpos,PLAYER_Y_POSITION, PLAYER_Z_POSITION);
        SetMaxPos(newRoomID);
        dogObj.GetComponent<Dog>().LoadingInNewRoom(new Vector3(newXpos,DOG_Y_POSITION,DOG_Z_POSITION));
        playerObj.GetComponent<PlayerController>().setCameraPos();
        currentRoomID = newRoomID;
    }

    public void LoadNextLevel()
    {
        LoadNewRoom(1, true);
        gameObject.GetComponent<LevelLoader>().UpdatLevelObjects(currentStateID,false);
        currentStateID++;
        dogObj.GetComponent<Dog>().currentState++;
        gameObject.GetComponent<LevelLoader>().UpdatLevelObjects(currentStateID,true);
        nextLevelScreenObj.GetComponent<NewLevelScreen>().LoadScreen(currentStateID, livesValue);
        isInNextLevelScreen = true;
        playerObj.GetComponent<PlayerController>().canMove = false;
        PlaySound(_LevelSoundClips[currentStateID]);
    }

    public void GameOver()
    {
        livesValue--;
        LoadNewRoom(1,true);
        gameObject.GetComponent<LevelLoader>().UpdatLevelObjects(currentStateID,false);
        gameObject.GetComponent<LevelLoader>().UpdatLevelObjects(currentStateID,true);
        nextLevelScreenObj.GetComponent<NewLevelScreen>().LoadScreen(currentStateID, livesValue);
        isInNextLevelScreen = true;
        dogObj.GetComponent<Dog>().ResetValuesAtGameOver();
        playerObj.GetComponent<PlayerController>().canMove = false;
    }

    public void RemoveHeldObject()
    {
        heldObject = 0;
        playerObj.GetComponent<PlayerController>().HoldingChange(false);
    }

    public void ForceStopPlayer()
    {
        playerObj.GetComponent<PlayerController>().forceStop = true;
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
                    if(proximityObj.GetComponent<Interactable>().GetContextID() == 1) CallTransitionScreen(10,2f); // this is for the vent
                    else CallTransitionScreen(0,0.5f);
                    if (currentRoomID == 3) LoadNextLevel();
                    else LoadNewRoom(currentRoomID + 1, true);
                } break;
                case 2: // Take Object
                {
                    if (heldObject == 0)
                    {
                        heldObject = proximityObj.GetComponent<Interactable>().GetContextID();
                        playerObj.GetComponent<PlayerController>().HoldingChange(true,proximityObj.GetComponent<Interactable>().heldObjectSprite);
                        proximityObj.GetComponent<Interactable>().DeleteThisObj();
                        PlaySound(2);
                        // 5 = scissors
                        // 6 = ball
                        // 7 = locker keys
                        // 8 = door key
                        // 9 = money
                    }
                } break;
                case 3: // Use box on stacks of boxes
                {
                    if (heldObject == 1)
                    {
                        PlaySound(12);
                        RemoveHeldObject();
                        proximityObj.GetComponent<StackOfBoxes>().UseObjectOnIt();
                    } break;
                }

                case 4: // Open door backward
                {
                    LoadNewRoom(currentRoomID -1, false);
                    CallTransitionScreen(0,0.5f);
                } break;
                case 5: // Hide
                {
                    playerObj.GetComponent<PlayerController>().HidePlayer(true);
                    playerObj.GetComponent<PlayerController>().StopAll();
                    PlaySound(3);
                    isHiding = true;
                } break;
                case 6: // cut this !
                {
                    if (heldObject == 5)
                    {
                        RemoveHeldObject();
                        proximityObj.GetComponent<Interactable>().InitiateNewObj(true);
                        proximityObj.GetComponent<Interactable>().DeleteThisObj();
                        PlaySound(5);   
                    }
                }break;
                case 7: // Start demo cutscene
                {
                    proximityObj.GetComponent<DemoMessageCutScene>().ActivateCutscene();
                } break;
                case 8: // throw ball
                {
                    RemoveHeldObject();
                    proximityObj.GetComponent<ShootBall>().ThrowBall();
                } break;
                case 9: // Unlock locker locks
                {
                    PlaySound(6);
                    RemoveHeldObject();
                    proximityObj.GetComponent<LockerLocks>().UseKeyOnIt();
                } break;
                case 10: // unlock door
                {
                    PlaySound(1);
                    RemoveHeldObject();
                    proximityObj.GetComponent<Interactable>().InitiateNewObj(true);
                } break;
                case 11: // Use machine
                {
                    if (proximityObj.TryGetComponent<VendingMachine>(out VendingMachine vendingMachine))
                    {
                        CallDialogue(vendingMachine.InteractWithIt(heldObject),null);
                    }
                    else
                    {
                        CallDialogue(proximityObj.GetComponent<DuplicatingMachine>().InteractWithIt(heldObject),null);
                        
                    }
                } break;
                case 12: // Switches
                {
                    proximityObj.GetComponent<SwitchController>().InteractWith();
                } break;
                case 13: // Cut Cage Rope
                {
                    RemoveHeldObject();
                    PlaySound(7);
                    proximityObj.GetComponent<CageRope>().CutIt();
                } break;
            }
        }
    }
}
