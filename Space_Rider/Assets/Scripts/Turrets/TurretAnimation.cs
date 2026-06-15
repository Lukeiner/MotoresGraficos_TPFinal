using UnityEngine;

public class TurretAnimation : MonoBehaviour
{
    public Transform startPoint;
    public Transform targetPoint;
    [SerializeField] private GameObject turret;

    [SerializeField] private GameObject actualTarget;

    void Start()
    {
        startPoint.position = transform.position; 

    }
    void Update()
    {
        if (actualTarget != null)
        {
            UpdateVisuals();
        }
        else
        {

        }
    }

    public void SetTarget(GameObject target)
    {

        actualTarget = target;

    }
    public void UpdateVisuals()
    {
        targetPoint = actualTarget.transform;
        Vector3 direction = (targetPoint.position - startPoint.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
