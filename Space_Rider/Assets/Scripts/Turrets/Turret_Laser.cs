 using UnityEngine;

public class Turret_Laser : Turret
{
    [SerializeField] private LaserBeam laserBeamPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected override void SetCurrentTarget()
    {
        // Simplemente elegimos el primero de la lista
        currentTarget = enemiesInRange.Count > 0 ? enemiesInRange[0] : null;
        laserBeamPrefab.SetTarget(currentTarget?.gameObject);
        turretAnimation.SetTarget(currentTarget?.gameObject);
    }
}
