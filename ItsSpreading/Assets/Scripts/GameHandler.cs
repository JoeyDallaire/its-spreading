using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler: MonoBehaviour
{
    [SerializeField] private float initialMaxRightPos;
    
    
    private float _maxRightPosition = 20f;
    [SerializeField] private List<Entity> entities = new List<Entity>();

    public void Start()
    {
        SetMaxRightPos(initialMaxRightPos);
    }
    
    public float GetMaxRightPos()
    {
        return _maxRightPosition;
    }

    public void SetMaxRightPos(float newObstaclePos)
    {
        foreach (var entity in  entities)
        {
            entity.setMaxRightPos(newObstaclePos);
        }
    }
}
