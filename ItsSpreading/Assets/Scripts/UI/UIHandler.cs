using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactableText;
    [SerializeField] private GameObject transitionScreen;

    private void Start()
    {
        interactableText.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void UpdateInteractableText(String action)
    {
        interactableText.GetComponent<TextMeshProUGUI>().text = action;
    }

    public void SetTransitionScreen(bool active)
    {
        transitionScreen.SetActive(active);
    }
    
    
}
