using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField] private GameObject gameHandlerObj;
    [SerializeField] public Animator _animator;
    
    private float _maxRightPos;
    private float _maxLeftPos;
    
    public float movementSpeed = 100f;
    public bool isSolid = true;

    public void Start()
    {
        
    }

    public void MoveThis(float direction)
    {
        float nextPos = gameObject.transform.position.x + direction;
        if ( nextPos >= _maxRightPos || nextPos < _maxLeftPos ) return;
        gameObject.transform.position += new Vector3(direction,0,0);
        gameObject.GetComponent<SpriteRenderer>().flipX = (direction < 0f);
    }

    public void SetMaxRightPos(float newMaxPos)
    {
        if(isSolid) _maxRightPos = newMaxPos;
    }
    
    public void SetMaxLeftPos(float newMaxPos)
    {
        if(isSolid) _maxLeftPos = newMaxPos;
    }


}
