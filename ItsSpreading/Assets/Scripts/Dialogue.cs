using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    private string message;
    private int spriteID;

    public Dialogue(string message, int spriteID)
    {
        this.message = message;
        this.spriteID = spriteID;
    }

    public string getText()
    {
        return message;
    }

    public int getSpriteID()
    {
        return spriteID;
    }

}
