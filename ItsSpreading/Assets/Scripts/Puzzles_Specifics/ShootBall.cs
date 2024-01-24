using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : Interactable
{
    [SerializeField] private GameObject ballObj;
    [SerializeField] private GameObject targetObj;    
    [SerializeField] private GameObject startThrowPosTag;
    [SerializeField] private float speed;
    [SerializeField] private float throwHeight;

    private bool isKeyNet = true; // if true, it throws to the key net, if false, it throws to the door net

    private Vector3 startPos;
    private Vector3 targetPos;

    private bool thrown;

    public void Start()
    {
        base.Start();
        if (targetObj.TryGetComponent<NetAndDoor>(out NetAndDoor netAndDoor))
        {
            isKeyNet = false;
        }

    }

    public void Update()
    {
        if(thrown) ballInThrow();
    }

    private void ballInThrow()
    {
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(ballObj.transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = throwHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, baseY + arc, ballObj.transform.position.z);

        ballObj.transform.position = nextPos;

        if (nextPos == targetPos)
        {
            thrown = false;
            ballObj.SetActive(false);
            if (isKeyNet)
            {
                targetObj.GetComponent<Interactable>().canInteract = true;
                targetObj.GetComponent<Interactable>().ChangeAction(2, "Take");
                targetObj.GetComponent<Interactable>().MoveThis();
                targetObj.GetComponent<AudioSource>().Play();
                gameObject.SetActive(false);
                return;
            }
            targetObj.GetComponent<AudioSource>().Play();
            targetObj.GetComponent<NetAndDoor>().AddBall();
        }
    }

    public void ThrowBall()
    {
        startPos = startThrowPosTag.transform.position;
        targetPos = targetObj.transform.position;
        ballObj.transform.position = startPos;
        thrown = true;
        ballObj.SetActive(true);
    }
}
