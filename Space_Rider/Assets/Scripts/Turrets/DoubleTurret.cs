using UnityEngine;

public class BobleTurret: Turret
{
    
    [SerializeField] private Transform leftFirePoint;
    [SerializeField] private Transform rightFirePoint;

    protected override void Shoot(Enemy enemy)
    {
        Debug.Log("Double shoot");
        enemy.TakeDamage(damage);
        enemy.TakeDamage(damage);
    }
}
