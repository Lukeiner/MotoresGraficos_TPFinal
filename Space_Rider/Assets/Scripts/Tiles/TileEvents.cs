using UnityEngine;

public static class TileEvents
{
    public static System.Action<TilesTurret> OnTileClicked;
    public static System.Action<TilesTurret> OnOpenTurretMenu;
    

    public static void SetTurret(TilesTurret tile, Turret turret)
    {
        tile.SetATurretPublic(turret);
    }
}