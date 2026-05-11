using UnityEngine;

public class PathPoint : MonoBehaviour
{
    Transform pathPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    public Vector3 GetPosition()
    {
        return pathPoint.position;
    }
    public void SetPosition(Vector3 pos)
    {
        pathPoint.position = pos;
    }
}
