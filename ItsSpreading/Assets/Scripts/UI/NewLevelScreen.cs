using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewLevelScreen : MonoBehaviour
{
    [SerializeField] private GameObject textObj;
    [SerializeField] private GameObject livesValueObj;

    private const string DEFAULT_TEXT = "Level : ";
    private const string DEFAULT_LIVES_TEXT = "x ";

    public void LoadScreen(int newLevelState, int livesValue)
    {
        gameObject.SetActive(true);
        textObj.GetComponent<TextMeshProUGUI>().text = DEFAULT_TEXT + newLevelState;
        livesValueObj.GetComponent<TextMeshProUGUI>().text = DEFAULT_LIVES_TEXT + livesValue;
    }

    public void DeleteScreen()
    {
        gameObject.SetActive(false);
    }
    
    
}
