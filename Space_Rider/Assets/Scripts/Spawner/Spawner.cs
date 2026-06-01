using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Configuración de nivel")]
    public LevelConfig levelConfig;
    public PathPoint spawnPoint;

    private void Start()
    {
        if (spawnPoint == null || levelConfig == null)
        {
            Debug.LogError("Spawner: you haven't assigned a spawn point or level config!");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        foreach (var wavesConfig in levelConfig.wavesConfigs)
        {
            foreach (var wave in wavesConfig.waves)
            {
                for (int i = 0; i < wave.count; i++)
                {
                    Instantiate(wave.enemyPrefab, spawnPoint.GetPosition(), Quaternion.identity);
                    yield return new WaitForSeconds(wave.spawnInterval);
                }
            }

            // Podés meter un delay entre waves si querés
            yield return new WaitForSeconds(2f);
        }
    }
}
