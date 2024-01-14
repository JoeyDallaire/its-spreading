using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float minPosition;
    [SerializeField] private float maxPosition;

    public void Update()
    {
        //gameObject.transform.position = (new Vector3(Mathf.Clamp(transform.position.x , minPosition, maxPosition),);
    }

    public void UpdateCamera(Vector3 playerPos)
    {
        transform.position = new Vector3(Mathf.Clamp(playerPos.x, minPosition, maxPosition), transform.position.y,
            transform.position.z);
    }

}
