using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAndDoor : MonoBehaviour
{
    [SerializeField] private GameObject handlerObj;
    private int nbOfBalls = 0;
    [SerializeField] private Sprite ballSprite1;
    [SerializeField] private Sprite ballSprite2;
    [SerializeField] private Sprite ballSprite3;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Sprite[] spriteArray;

    [SerializeField] private float distanceEachLower;
    [SerializeField] private GameObject doorObj;
    
    private void Start()
    {
        spriteArray = new Sprite[4] { null, ballSprite1, ballSprite2, ballSprite3 };
    }

    public void AddBall()
    {
        nbOfBalls++;
        _spriteRenderer.sprite = spriteArray[nbOfBalls];
        LowerThis();
        if (nbOfBalls == 3) ActivateDoor();
    }

    private void ActivateDoor()
    {
        handlerObj.GetComponent<GameHandler>().CallDialogueByValue(22);
        doorObj.SetActive(true);
    }

    private void LowerThis()
    {
        transform.position -= new Vector3(0f,distanceEachLower,0f);
    }
    
}
