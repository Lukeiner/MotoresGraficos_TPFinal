using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private List<TurretStoreData> turretStoreDataList;  // Lista de datos de torretas para la tienda
    [SerializeField] private Transform storeUIParent;  // Parent para los elementos de la UI de la tienda
    [SerializeField] private GameObject turretStoreUIPrefab;  // Prefab para
    private TurretUIConstructor turretUIConstructor;  // Referencia al constructor de UI de torretas
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
