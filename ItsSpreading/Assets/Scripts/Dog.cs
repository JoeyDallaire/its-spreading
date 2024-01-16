using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Entity
{
    // Following related
    [SerializeField] private GameObject playerObj;
    private const float MAX_DIST_FROM_PLAYER = 3f;
    private const float SPEED_MULTIPLIER = 0.03f;
    
    // State related
    public bool exists = true;
    private const int NEXT_STATE_1 = 3;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }


    private void FollowPlayer()
    {
        if (Math.Abs(playerObj.transform.position.x - transform.position.x) > MAX_DIST_FROM_PLAYER)
        {
            MoveThis((playerObj.transform.position.x - transform.position.x)*SPEED_MULTIPLIER);
        }
    }


    public void LoadingInNewRoom(Vector3 newPosition)
    {
        if(exists)this.transform.position = newPosition;
    }
    
    
}
