using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContactDialogue : MonoBehaviour
{
    [SerializeField] private int dialogueID;
    [SerializeField] private GameObject switchOtherDialogue;
    
    private GameObject playerObj;
    private GameObject handlerObj;

    private const float DISTANCE_TO_TRIGGER = 3f;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
        handlerObj = playerObj.transform.Find("Handler").gameObject;
    }

    private void Update()
    {
        if (Mathf.Abs(playerObj.transform.position.x - transform.position.x) < DISTANCE_TO_TRIGGER) callDialogue();
    }

    private void callDialogue()
    {
        handlerObj.GetComponent<GameHandler>().CallDialogueByValue(dialogueID);
        if (switchOtherDialogue != null) switchOtherDialogue.SetActive(!switchOtherDialogue.activeInHierarchy);
        Destroy(gameObject);
    }
    
    
}
