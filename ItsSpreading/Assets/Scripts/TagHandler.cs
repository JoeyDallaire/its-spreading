using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagHandler : MonoBehaviour
{
    
    // These two lists will hold the tags for each rooms, the room id is represented by the list index; index 0 = null
    [SerializeField] private List<GameObject> LeftTags = new List<GameObject>();
    [SerializeField] private List<GameObject> RightTags = new List<GameObject>();
    [SerializeField] private List<GameObject> PlayerStartTags = new List<GameObject>();

    public float GetMaxPos(bool getLeft, int roomID)
    {
        if (getLeft) return LeftTags[roomID].transform.position.x;
        return RightTags[roomID].transform.position.x;
    }

    public float GetPlayerPosNewRoom(int roomID)
    {
        return PlayerStartTags[roomID].transform.position.x;
    }
    
    
}
