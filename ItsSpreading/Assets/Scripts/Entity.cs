using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField] private GameObject gameHandlerObj;
    
    
    private float _maxRightPosition = 10000f; // set to absurd amount so it never collides with anything if not solid
    
    [SerializeField] private float _maxLeftPos;
    
    
    
    public float movementSpeed = 2f;
    public bool isSolid = true;

    public void Start()
    {
    }

    public void MoveThis(float direction)
    {
        float nextPos = gameObject.transform.position.x + direction;
        if ( nextPos >= _maxRightPosition || nextPos < _maxLeftPos ) return;
        gameObject.transform.position += new Vector3(direction,0,0);
    }

    public void setMaxRightPos(float newMaxPos)
    {
        if(isSolid) _maxRightPosition = newMaxPos;
    }

}
