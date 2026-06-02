using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Transform startPoint;
    public Transform targetPoint;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private GameObject particleSystemGameObject;

    void Start()
    {
        startPoint.position = transform.position; 
        particleSystem.transform.position = startPoint.position;
    }

    public void SetTarget(Transform target)
    {
        targetPoint = target;
        Vector3 direction = (targetPoint.position - startPoint.position).normalized;
        float distance = Vector3.Distance(startPoint.position, targetPoint.position);

        // Ajusta la escala del sistema de partículas para que alcance el objetivo
        particleSystem.transform.localScale = new Vector3(1, 1, 1);
        particleSystemGameObject.transform.rotation = Quaternion.LookRotation(direction);
    }
}
