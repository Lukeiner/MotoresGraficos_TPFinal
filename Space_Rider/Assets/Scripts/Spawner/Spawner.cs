using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]

    public Enemy[] enemyPreFabs;

    [Header("Posiciones")]
    public PathPoint spawnPoint;
    public Transform endPoint;

    [Header("Configuracion")]
    public float spawnInterval = 2f;

    private Vector3 target;

    private void Start()
    {
        if (spawnPoint == null || endPoint == null)
        {
            Debug.LogError("EnemySpawner: faltan asignar spawnPoint o endPoint en el inspector");
            return;
        }
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Enemy prefab = enemyPreFabs[Random.Range(0, enemyPreFabs.Length)];
        Enemy enemy = Instantiate(prefab, spawnPoint.GetPosition(), Quaternion.identity);
        enemy.SetTarget(endPoint.position);
    }

    public void SetTarget(Vector3 t)
    {
        target = t;
    }
}
