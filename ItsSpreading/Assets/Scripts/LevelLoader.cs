using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Specific Objects")]
    [SerializeField] private GameObject cafetDoorObj;
    [SerializeField] private GameObject couloirDoorObj;
    [SerializeField] private GameObject couloirLeftDoorObj;
    [SerializeField] private GameObject gymLastDoorObj;
    [SerializeField] private GameObject gymLeftDoorObj;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject dogObj;
    [SerializeField] private GameObject gymLastDoorSprite;
    [SerializeField] private GameObject stuffDeletelvl12;
    
    [Header("Level Folders")]
    
    [SerializeField] private GameObject levelObj0;
    [SerializeField] private GameObject levelObj1;
    [SerializeField] private GameObject levelObj2;
    [SerializeField] private GameObject levelObj3;
    [SerializeField] private GameObject levelObj4;
    [SerializeField] private GameObject levelObj5;
    [SerializeField] private GameObject levelObj6;
    [SerializeField] private GameObject levelObj7;
    [SerializeField] private GameObject levelObj8;
    [SerializeField] private GameObject levelObj9;
    [SerializeField] private GameObject levelObj10;
    [SerializeField] private GameObject levelObj11;
    [SerializeField] private GameObject levelObj12;
    [SerializeField] private GameObject levelObj13;

    public void UpdatLevelObjects(int levelID,bool active)
    {
        levelID-=1; // To make the value consistent with actual level numbers
        switch (levelID)
        {
            case 0:
            {
                gymLastDoorObj.SetActive(!active);
                levelObj0.SetActive(active);
            } break;
            case 1:
            {
                levelObj1.SetActive(active);
            } break;
            case 2:
            {
                gymLastDoorObj.SetActive(!active);
                levelObj2.SetActive(active);
            } break;
            case 3:
            {
                lockObj.SetActive(!active);
                gymLastDoorObj.SetActive(!active);
                levelObj3.SetActive(active);
            } break;
            case 4:
            {
                gymLastDoorSprite.SetActive(!active);
                gymLastDoorObj.SetActive(!active);
                levelObj4.SetActive(active);
            } break;
            case 5:
            {
                gymLastDoorObj.SetActive(!active);
                levelObj5.SetActive(active);
            } break;
            case 6:
            {
                levelObj6.SetActive(active);
            } break;
            case 7:
            {
                gymLastDoorObj.SetActive(!active);
                levelObj7.SetActive(active);
            } break;
            case 8:
            {
                levelObj8.SetActive(active);
            } break;
            case 9:
            {
                dogObj.GetComponent<Dog>().ResetValuesAtGameOver();
                lockObj.SetActive(!active);
                levelObj9.SetActive(active);
            } break;
            case 10:
            {
                dogObj.GetComponent<Dog>().ResetValuesAtGameOver();
                lockObj.SetActive(!active);
                levelObj10.SetActive(active);
            } break;
            case 11:
            {
                dogObj.GetComponent<Dog>().ResetValuesAtGameOver();
                gymLastDoorObj.SetActive(!active);
                lockObj.SetActive(!active);
                levelObj11.SetActive(active);
            } break;
            case 12:
            {
                cafetDoorObj.GetComponent<Interactable>().CheckSpriteAvailable();
                couloirDoorObj.GetComponent<Interactable>().CheckSpriteAvailable();
                couloirLeftDoorObj.GetComponent<Interactable>().CheckSpriteAvailable(); 
                gymLeftDoorObj.GetComponent<Interactable>().CheckSpriteAvailable(); 
                gymLastDoorObj.GetComponent<Interactable>().CheckSpriteAvailable();
                
                cafetDoorObj.GetComponent<SpriteRenderer>().enabled = active;
                couloirDoorObj.GetComponent<SpriteRenderer>().enabled = active;
                couloirLeftDoorObj.GetComponent<SpriteRenderer>().enabled = active;
                gymLeftDoorObj.GetComponent<SpriteRenderer>().enabled = active;
                gymLastDoorObj.GetComponent<SpriteRenderer>().enabled = active;
                
                stuffDeletelvl12.SetActive(false);
                
                
                levelObj12.SetActive(active);
            } break;
            case 13:
            {
                levelObj13.SetActive(active);
                gameObject.GetComponent<GameHandler>().ForceStopPlayer();
            } break;
        }
    }

    
    
}
