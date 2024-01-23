using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Specific Objects")]
    [SerializeField] private GameObject couloirDoorObj;
    [SerializeField] private GameObject gymLastDoorObj;
    [SerializeField] private GameObject gymLeftDoorObj;
    [SerializeField] private GameObject lockObj;
    
    [Header("Level Folders")]
    
    [SerializeField] private GameObject levelObj0;
    [SerializeField] private GameObject levelObj1;
    [SerializeField] private GameObject levelObj2;
    [SerializeField] private GameObject levelObj3;
    [SerializeField] private GameObject levelObj4;
    [SerializeField] private GameObject levelObj5;
    [SerializeField] private GameObject levelObj6;
    [SerializeField] private GameObject levelobj7;

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
                
            } break;
            case 2:
            {
                couloirDoorObj.SetActive(!active);
                gymLeftDoorObj.SetActive(!active);
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
                levelobj7.SetActive(active);
            } break;
        }
    }

    
    
}
