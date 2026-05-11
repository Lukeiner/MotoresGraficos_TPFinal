using UnityEngine;

public class BasicTurret : Turret
{
    [SerializeField] protected Transform firePoint;

    protected override void Shoot(Enemy enemy)
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        bullet.SetTarget(enemy);
        bullet.SetDamage(damage);
    }
}
