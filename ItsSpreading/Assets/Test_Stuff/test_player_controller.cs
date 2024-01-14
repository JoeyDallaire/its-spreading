using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_player_controller : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const float SPEED = 1f;
    private float currentSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = SPEED;
        }
        else currentSpeed = 0;
        
        
        _animator.SetFloat("speed_anim", currentSpeed);

    }
}
