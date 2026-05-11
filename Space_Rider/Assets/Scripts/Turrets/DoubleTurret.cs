using UnityEngine;

public class BobleTurret: Turret
{
    
    [SerializeField] private Transform leftFirePoint;
    [SerializeField] private Transform rightFirePoint;

    protected override void Shoot(Enemy enemy)
    {
        Debug.Log("Double shoot");

        if (bulletPrefab == null) return;

        GameObject bulletLeft = Instantiate(bulletPrefab, leftFirePoint.position, leftFirePoint.rotation);
        Bullet bulletCompLeft = bulletLeft.GetComponent<Bullet>();
        bulletCompLeft.SetTarget(enemy);
        bulletCompLeft.SetDamage(damage);

        GameObject bulletRight = Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);
        Bullet bulletCompRight = bulletRight.GetComponent<Bullet>();
        bulletCompRight.SetTarget(enemy);
        bulletCompRight.SetDamage(damage);
    }
}
