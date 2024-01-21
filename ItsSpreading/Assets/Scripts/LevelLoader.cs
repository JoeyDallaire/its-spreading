using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject couloirDoorObj;
    [SerializeField] private GameObject gymLastDoorObj;
    
    [SerializeField] private GameObject levelObj0;
    [SerializeField] private GameObject levelObj1;

    public void UpdatLevelObjects(int levelID,bool active)
    {
        switch (levelID)
        {
            case 1:
            {
                gymLastDoorObj.SetActive(!active);
                levelObj0.SetActive(active);
            }
                break;
            case 2:
            {
                couloirDoorObj.SetActive(!active);
                levelObj1.SetActive(active);
            }
                break;
        }
    }

    
    
}
