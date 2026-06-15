using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Scriptable Objects/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [Header("Oleadas del nivel")]
    public List<WavesConfig> wavesConfigs;  // lista de assets WavesConfig
}
