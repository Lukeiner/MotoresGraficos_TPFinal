using System;
using UnityEngine;

// TileEvents: solo selección
public static class TileEvents {
    public static Action<TilesTurret> OnTileClicked;
    public static Action<TilesTurret> OnOpenTurretMenu;
    public static Action OnCloseTurretMenu;

    private static TilesTurret selectedTile;

    public static void SelectTile(TilesTurret tile) {
        selectedTile = tile;
        OnOpenTurretMenu?.Invoke(tile);
        Debug.Log("Tile selected: " + tile.name);
    }

    public static TilesTurret GetSelectedTile() => selectedTile;
}
