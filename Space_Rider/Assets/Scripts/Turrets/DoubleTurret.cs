using UnityEngine;

public class BobleTurret: Turret
{
    protected override void Shoot(Enemy enemy)
    {
        Debug.Log("Double shoot");
        enemy.TakeDamage(damage);
        enemy.TakeDamage(damage);
    }
}
