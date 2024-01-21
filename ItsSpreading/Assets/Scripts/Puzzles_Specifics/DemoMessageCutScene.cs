using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DemoMessageCutScene : Interactable
{
    [SerializeField] private float timeToWait;
    
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject scissorsObj;
    [SerializeField] private GameObject uiFolder;

    public void ActivateCutscene()
    {
        playerObj.GetComponent<PlayerController>().canMove = false;
        uiFolder.SetActive(true);
        StartCoroutine(FirstCutSceneCoroutine());

    }

    private IEnumerator FirstCutSceneCoroutine()
    {
        yield return new WaitForSeconds(timeToWait);
        SpawnScissor();
        StartCoroutine(SecondCutSceneCoroutine());
    }
    
    private IEnumerator SecondCutSceneCoroutine()
    {
        yield return new WaitForSeconds(timeToWait);
        playerObj.GetComponent<PlayerController>().canMove = true;
        uiFolder.SetActive(false);
        DeleteThisObj();
    }

    private void SpawnScissor()
    {
        scissorsObj.SetActive(true); //TODO make some fucking animation 
    }
    
}
