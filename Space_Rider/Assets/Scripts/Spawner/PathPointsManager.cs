using System;
using UnityEngine;

public class PathPointsManager : MonoBehaviour
{
    [SerializeField] private PathPoint[] pathPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PathPointsEvents.OnNextPathPoint += GetPathPoint;
    }

    // Update is called once per frame
    public PathPoint GetPathPoint(Enemy actualEnemy)
    {
        if (actualEnemy < 0 || actualEnemy >= pathPoints.Length)
        {
            Debug.LogError("PathPointsManager: índice fuera de rango");
            return null;
        }
        return pathPoints[actualEnemy];
    }


}
