using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    private void OnEnable()
    {
        TileEvents.OnTileClicked += HandleTileClick;
        TileEvents.OnOpenTurretMenu += HandleOpenTurretMenu;
    }

    private void OnDisable()
    {
        TileEvents.OnTileClicked -= HandleTileClick;
        TileEvents.OnOpenTurretMenu -= HandleOpenTurretMenu;
    }

    private void HandleTileClick(TilesTurret tile)
    {
        Debug.Log("Tile con torreta clickeado: " + tile.name);
        if (currencyManager.TrySpend(60))
        {
            Debug.Log("Turret upgraded on " + tile.name);
            tile.GetActualTurret().Upgrade();
        }
        else
        {
            Debug.Log("Not enough currency to upgrade turret.");
        }
        
    }

    private void HandleOpenTurretMenu(TilesTurret tile)
    {
        Debug.Log("Abrir menú de construcción en: " + tile.name);
        if (currencyManager.TrySpend(50))
        {
            tile.SetATurretPublic(new Turret());
            Debug.Log("turret built on " + tile.name);
        }
        else
        {
            Debug.Log("Not enough currency to build turret.");
        }

        
    }
}
