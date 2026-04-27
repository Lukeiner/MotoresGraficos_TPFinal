using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        
    }

    private void HandleOpenTurretMenu(TilesTurret tile)
    {
        Debug.Log("Abrir menú de construcción en: " + tile.name);
        
    }
}
