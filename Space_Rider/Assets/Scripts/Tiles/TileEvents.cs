using UnityEngine;

public static class TileEvents
{
    public static System.Action<TilesTurret> OnTileClicked;
    public static System.Action<TilesTurret> OnOpenTurretMenu;

    public static System.Action OnCloseTurretMenu;
    private static TilesTurret selectedTile;
    

    public static void SetTurret(Turret turret)
    {
        selectedTile.SetATurretPublic(turret);
    }
    private static void OnEnable()
    {
        OnTileClicked += HandleTileClicked;
    }
    private static void OnDisable()
    {
        OnTileClicked -= HandleTileClicked;
    }
    private static void HandleTileClicked(TilesTurret tile)
    {
        selectedTile = tile;
        OnOpenTurretMenu?.Invoke(tile);
    }
    
}