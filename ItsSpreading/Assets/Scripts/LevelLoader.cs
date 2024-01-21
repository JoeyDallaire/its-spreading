using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject couloirDoorObj;
    [SerializeField] private GameObject gymLastDoorObj;
    
    [SerializeField] private GameObject levelObj0;
    [SerializeField] private GameObject levelObj1;
    [SerializeField] private GameObject levelObj2;
    [SerializeField] private GameObject levelObj3;
    [SerializeField] private GameObject levelObj4;
    [SerializeField] private GameObject levelObj5;
    [SerializeField] private GameObject levelObj6;

    public void UpdatLevelObjects(int levelID,bool active)
    {
        switch (levelID)
        {
            case 1:
            {
                gymLastDoorObj.SetActive(!active);
                levelObj0.SetActive(active);
            } break;
            case 2:
            {
                
            } break;
            case 3:
            {
                couloirDoorObj.SetActive(!active);
                levelObj2.SetActive(active);
            } break;
            case 5:
            {
                levelObj4.SetActive(active);
            } break;
        }
    }

    
    
}
