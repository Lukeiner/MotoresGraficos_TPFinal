using System;
using UnityEngine;

public class PathPointsManager : MonoBehaviour
{
    [SerializeField] private PathPoint[] pathPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public PathPoint GetPathPoint(int index)
    {
        if (index < 0 || index >= pathPoints.Length)
        {
            Debug.LogError("PathPointsArray: índice fuera de rango");
            return null;
        }
        return pathPoints[index];
    }
    

}
