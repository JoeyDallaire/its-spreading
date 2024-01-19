using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewLevelScreen : MonoBehaviour
{
    [SerializeField] private GameObject textObj;
    [SerializeField] private GameObject livesValueObj;

    private int[] levelTrueNames = {0, 10, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10};
    
    private const string DEFAULT_TEXT = "Level : ";
    private const string DEFAULT_LIVES_TEXT = "x ";

    private void Start()
    {
        textObj.GetComponent<TextMeshProUGUI>().color = Color.white;
        livesValueObj.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void LoadScreen(int newLevelState, int livesValue)
    {
        gameObject.SetActive(true);
        textObj.GetComponent<TextMeshProUGUI>().text = DEFAULT_TEXT + levelTrueNames[newLevelState];
        livesValueObj.GetComponent<TextMeshProUGUI>().text = DEFAULT_LIVES_TEXT + livesValue;
    }

    public void DeleteScreen()
    {
        gameObject.SetActive(false);
    }
    
    
}
