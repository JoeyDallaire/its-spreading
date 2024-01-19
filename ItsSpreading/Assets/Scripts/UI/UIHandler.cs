using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactableText;

    private void Start()
    {
        interactableText.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void UpdateInteractableText(String action)
    {
        interactableText.GetComponent<TextMeshProUGUI>().text = action;
    }
    
    
}
