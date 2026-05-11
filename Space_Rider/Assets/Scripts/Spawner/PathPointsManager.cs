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
    public void GetPathPoint(Enemy actualEnemy)
    {
        int actualIndex = actualEnemy.GetActualPathPointIndex();
        if (actualIndex >= pathPoints.Length)
        {
            actualEnemy.ReachEnd();
            return;
            Debug.LogError("PathPointsManager: índice fuera de rango");
            
        }
        actualEnemy.SetTarget(pathPoints[actualIndex].GetPosition());
        actualEnemy.IncrementPathPointIndex();
    }

    


}
