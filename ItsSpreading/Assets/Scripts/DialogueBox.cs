using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    private const int MAX_CHAR_LENGHT = 100;
    
    private string text;
    
    
    public DialogueBox(string text)
    {
        this.text = text;
    }
}
