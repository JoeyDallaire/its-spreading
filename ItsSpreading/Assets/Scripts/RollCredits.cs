using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : MonoBehaviour
{
    public float speed;
    private Vector3 speedVector;
    [SerializeField] private float maxPos = 51.9f;
    private bool stillRollin;
    private void Start()
    {
        speedVector = new Vector3(0f, speed, 0f);
    }

    void FixedUpdate()
    {
        if(stillRollin) transform.position += speedVector;
        stillRollin = (transform.position.y < maxPos);
    }
}
