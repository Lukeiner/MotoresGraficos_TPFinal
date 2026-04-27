using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int reward = 50;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashDuration = 0.1f;

    private Color originalColor;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
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

    private void Die()
    {
        CurrencyEvents.OnEnemyKilled?.Invoke(this);
        Destroy(gameObject);
    }

    public int GetReward()
    {
        return reward;
    }
}
