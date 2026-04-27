using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NormalEnemy : Enemy
{
    public float velocity = 1f;

    private void Start()
    {
      
    }
     void Update()
    {
        if (this == null || arrived) return;

        transform.position = Vector3.MoveTowards(transform.position, target, this.velocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            arrived = true;
            ReachEnd();
        }

    }

    protected override void ReachEnd()
    {
        if (this == null) return; // ya fue destruido
        Destroy(gameObject);
    }

    public void setTarget(Vector3 t)
    {
        target = t;
    }


}
