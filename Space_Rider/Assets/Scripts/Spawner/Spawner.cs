using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Configuración de nivel")]
    public WavesConfig levelConfig;   
    public PathPoint spawnPoint;

    private void Start()
    {
        if (spawnPoint == null || levelConfig == null)
        {
            Debug.LogError("Spawner: faltan asignar spawnPoint o levelConfig en el inspector");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        foreach (var wave in levelConfig.waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                Instantiate(wave.enemyPrefab, spawnPoint.GetPosition(), Quaternion.identity);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }
    }

}
