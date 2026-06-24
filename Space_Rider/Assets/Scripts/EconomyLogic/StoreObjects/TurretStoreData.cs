using UnityEngine;

[CreateAssetMenu(fileName = "TurretStoreData", menuName = "Scriptable Objects/TurretStoreData")]
public class TurretStoreData : ScriptableObject
{
    [Header("Datos de la torreta")]
    public string turretName;
    public int cost;
    public Sprite sprite;  // Imagen para mostrar en la tienda
    public GameObject turretPrefab;
    
    
    // Prefab de la torreta para instanciar

}
