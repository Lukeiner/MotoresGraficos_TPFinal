using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int health = 100;
    [SerializeField] protected int reward = 50;
    [SerializeField] protected float velocity = 1f;
    [Header("Visuals")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private int actualPathPointIndex = 0;
    protected Vector3 target;
    protected bool arrived = false;

    private Color originalColor;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (this == null || arrived) return;

        transform.position = Vector3.MoveTowards(transform.position, target, this.velocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            arrived = true;
            GetNextPathPoint();
            
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void FlashDamage()
    {
        spriteRenderer.color = damageColor;
        Invoke(nameof(ResetColor), flashDuration);
    }

    private void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }

    protected void Die()
    {
        CurrencyEvents.OnEnemyKilled?.Invoke(this);
        if (this == null) return;
        Destroy(gameObject);
    }

    public int GetReward()
    {
        return reward;
    }

    protected virtual void GetNextPathPoint()
    {
        PathPointsEvents.OnNextPathPoint?.Invoke(this);
        arrived = false;
        
    }
    protected virtual void ReachEnd()
    {
        if (this == null) return; // ya fue destruido
        Destroy(gameObject);
    }


    public void SetTarget(Vector3 t)
    {
        target = t;
    }

    public int GetActualPathPointIndex()
    {
        return actualPathPointIndex;
    }
    public void IncrementPathPointIndex()
    {
        actualPathPointIndex++;
    }
        public void setTarget(Vector3 t)
    {
        target = t;
    }
}
