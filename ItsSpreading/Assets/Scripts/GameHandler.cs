using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler: MonoBehaviour
{
    private const float MAX_DIST_FROM_INTERACTABLE = 2f;
    
    
    [SerializeField] private float initialMaxRightPos;
    
    private float _maxRightPosition = 20f;
    [SerializeField] private List<Entity> entities = new List<Entity>();

    [SerializeField] private GameObject dialogueBoxObj;
    [SerializeField] private GameObject playerObj;

    private GameObject proximityObj;
    [SerializeField] private List<GameObject> interactableObjs = new List<GameObject>();
    
    private bool isInDialogue = true;
    
    
    public void Start()
    {
        SetMaxRightPos(initialMaxRightPos);
    }

    public void Update()
    {
        UpdateProximityObj();
    }

    public float GetMaxRightPos()
    {
        return _maxRightPosition;
    }

    public void SetMaxRightPos(float newObstaclePos)
    {
        foreach (var entity in  entities)
        {
            entity.setMaxRightPos(newObstaclePos);
        }
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
}
