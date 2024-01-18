﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject levelObj0;
    [SerializeField] private GameObject levelObj1;

    public void UpdatLevelObjects(int levelID,bool active)
    {
        switch (levelID)
        {
            case 1: levelObj0.SetActive(active);
                break;
            case 2: levelObj1.SetActive(active);
                break;
        }
    }

    
    
}
