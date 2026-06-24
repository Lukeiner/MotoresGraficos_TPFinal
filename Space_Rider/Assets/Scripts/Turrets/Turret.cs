using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [SerializeField] protected int level = 1;
    [SerializeField] protected float range = 4f;
    [SerializeField] protected int damage = 50;
    [SerializeField] protected float fireRate = 2f;

    [SerializeField] protected TurretAnimation turretAnimation;

    protected List<Enemy> enemiesInRange = new List<Enemy>();
    protected Enemy currentTarget;

    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.green);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void Upgrade()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (level == 1)
        {
            level = 2;
            range += 2f;
            damage += 25;
            Debug.Log("Turret upgraded to level 2");
            collider.radius = range;
        }
        else if (level == 2)
        {
            level = 3;
            range += 1f;
            damage += 50;
            Debug.Log("Turret upgraded to level 3");
            collider.radius = range;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
            Debug.Log("Enemy entered range: " + enemy.name);

            // Si no tenemos target actual, lo seteamos
            if (currentTarget == null)
            {
                SetCurrentTarget();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
            Debug.Log("Enemy left range: " + enemy.name);

            // Si el que salió era el target actual, buscamos otro
            if (currentTarget == enemy)
            {
                SetCurrentTarget();
            }
        }
    }

    protected virtual void SetCurrentTarget()
    {
        // Simplemente elegimos el primero de la lista
        currentTarget = enemiesInRange.Count > 0 ? enemiesInRange[0] : null;
        turretAnimation.SetTarget(currentTarget?.gameObject);
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            if (currentTarget != null)
            {
                Shoot(currentTarget);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot(Enemy enemy)
    {
        if (enemy == null || enemy.gameObject == null)
        {
            enemiesInRange.Remove(enemy);
            SetCurrentTarget();
            return;
        }

        Debug.Log("Shooting at enemy: " + enemy.name);
        enemy.TakeDamage(damage);

    }
}
