using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Transform startPoint;
    public Transform targetPoint;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private GameObject particleSystemGameObjectRay;
    [SerializeField] private GameObject particleSystemGameObjectImpact;
    [SerializeField] private GameObject actualTarget;

    void Start()
    {
        startPoint.position = transform.position; 
        particleSystem.transform.position = startPoint.position;
    }
    void Update()
    {
        if (actualTarget != null)
        {
            UpdateVisuals();
        }
        else
        {
            particleSystemGameObjectRay.SetActive(false);
            particleSystemGameObjectImpact.SetActive(false);
        }
    }

    public void SetTarget(GameObject target)
    {

        actualTarget = target;

        particleSystemGameObjectRay.SetActive(true);
        particleSystemGameObjectImpact.SetActive(true);
    }
    public void UpdateVisuals()
    {
        targetPoint = actualTarget.transform;
        Vector3 direction = (targetPoint.position - startPoint.position).normalized;
        float distance = Vector3.Distance(startPoint.position, targetPoint.position);

        particleSystem.transform.localScale = new Vector3(-distance/2f, 1, 1);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        particleSystemGameObjectRay.transform.rotation = Quaternion.Euler(0, 0, angle);
        particleSystemGameObjectImpact.transform.position = targetPoint.position;
    }
}
