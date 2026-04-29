using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private float range = 4f;
    [SerializeField] private int damage = 50;
    [SerializeField] private float fireRate = 2f;

    private List<Enemy> enemiesInRange = new List<Enemy>();

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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
            Debug.Log("Enemy left range: " + enemy.name);
        }
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            if (enemiesInRange.Count > 0)
            {
                Enemy target = enemiesInRange[0]; 
                if (target != null)
                {
                    Shoot(target);
                }
                else
                {
                    enemiesInRange.RemoveAt(0); 
                }
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot(Enemy enemy)
    {
        Debug.Log("Shooting at enemy: " + enemy.name);
        enemy.TakeDamage(damage);

        if (enemy == null || enemy.gameObject == null)
        {
            enemiesInRange.Remove(enemy);
        }
    }
}
