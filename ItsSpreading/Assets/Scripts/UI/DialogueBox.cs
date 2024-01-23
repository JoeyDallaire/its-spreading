using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject imageObj;
    [SerializeField] private GameObject textObj;
    [SerializeField] private GameObject pannel;
    
    private const int MAX_CHAR_LENGHT = 120;


    public void callDialogueBox(string text, Sprite faceImg)
    {
        
        pannel.SetActive(true);
        if(faceImg == null) imageObj.SetActive(false);
        else imageObj.GetComponent<Image>().sprite = faceImg;
        textObj.GetComponent<TextMeshProUGUI>().text = text;
        
    }

    public void DeleteCurrentDialogueBox()
    {
        pannel.SetActive(false);
    }
    
}
