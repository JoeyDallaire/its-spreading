using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject handlerObj;
    private float distanceToKill = 3f;
    
    private void Update()
    {
        if (Math.Abs(playerObj.transform.position.x - transform.position.x) < distanceToKill)
        {
            handlerObj.GetComponent<GameHandler>().GameOver();
        }
    }

    public void DestroyWall()
    {
        gameObject.SetActive(false);
    }
}
