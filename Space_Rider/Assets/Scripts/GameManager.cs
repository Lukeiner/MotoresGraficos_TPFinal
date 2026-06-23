using UnityEngine;

// GameManager: orquesta
public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    [SerializeField] private CurrencyManager currencyManager;

    private void Awake() => Instance = this;

    public void TryBuildTurret(GameObject prefab, int cost) {
        var tile = TileEvents.GetSelectedTile();
        Debug.Log("Selected tile: " + (tile != null ? tile.name : "None"));
        if (tile == null) return;

        if (currencyManager.TrySpend(cost)) {
            tile.SetATurretPublic(Instantiate(prefab,tile.transform).GetComponentInChildren<Turret>());
            Debug.Log("Turret built!");
        } else {
            Debug.Log("Not enough currency!");
        }
    }
}

