using Unity.VisualScripting;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] private int playerHealth = 5;
    void Start()
    {
        EnemyEvents.OnEnemyHitBase += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("PlayerLifeManager: actual health: " + playerHealth);
        if (playerHealth <= 0)
        {
            Debug.LogError("PlayerLifeManager: player is dead");
        }
    }
}
