using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WavesConfig", menuName = "Scriptable Objects/WavesConfig")]
public class WavesConfig : ScriptableObject
{
    [System.Serializable]
    public class Wave
    {
        public Enemy enemyPrefab;  
        public int count;   
        public float spawnInterval;   
    }

    public List<Wave> waves;  
}
