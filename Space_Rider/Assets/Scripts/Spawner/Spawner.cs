using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Configuración de nivel")]
    public LevelConfig levelConfig;
    public PathPoint spawnPoint;

    private int currentWaveIndex = -1; // empieza en -1, así el botón avanza a 0

    private void Start()
    {
        if (spawnPoint == null || levelConfig == null)
        {
            Debug.LogError("Spawner: you haven't assigned a spawn point or level config!");
            return;
        }
    }

    private IEnumerator SpawnRoutine(WavesConfig waveConfig)
    {
        foreach (var wave in waveConfig.waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                Instantiate(wave.enemyPrefab, spawnPoint.GetPosition(), Quaternion.identity);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }
    }

    public void NextWave()
    {
        // Avanzamos al siguiente índice
        currentWaveIndex++;

        if (currentWaveIndex < levelConfig.wavesConfigs.Count)
        {
            StopAllCoroutines();
            StartCoroutine(SpawnRoutine(levelConfig.wavesConfigs[currentWaveIndex]));
            Debug.Log("Starting wave " + (currentWaveIndex + 1));
        }
        else
        {
            Debug.Log("No more waves!");
        }
    }
}
