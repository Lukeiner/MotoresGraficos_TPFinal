using UnityEngine;
using System.Collections;

public class LaserTurret : Turret
{
    [SerializeField] private float laserDuration = 3f;
    [SerializeField] private float cooldownDuration = 2f;
    [SerializeField] private int laserDamage = 10;

    protected override IEnumerator FireRoutine()
    {
        while (true)
        {
            if (enemiesInRange.Count > 0)
            {
                Enemy target = enemiesInRange[0];

                float timer = 0f;

                Debug.Log("Laser firing");

                while (timer < laserDuration && target != null)
                {
                    target.TakeDamage(laserDamage);

                    timer += 1f;

                    yield return new WaitForSeconds(1f);
                }

                Debug.Log("Laser overheated");

                yield return new WaitForSeconds(cooldownDuration);
            }

            yield return null;
        }
    }
}
