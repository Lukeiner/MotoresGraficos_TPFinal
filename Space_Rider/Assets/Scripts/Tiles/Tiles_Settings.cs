using System.Collections.Generic;
using UnityEngine;



public class Tiles_Settings : MonoBehaviour
{
    [SerializeField] private Tiles[][] tiles;
    [SerializeField] private List<BoolRow> routeTiles;
    [SerializeField] public int tilesSizeHorizontalLenght;
    [SerializeField] public int tilesSizeVerticalLenght;
    [SerializeField] private Tiles enemyPortalTile;
    [SerializeField] private int[][] enemyPortalTilePosition;
    [SerializeField] private Tiles baseTile;
    [SerializeField] private int[][] baseTilePosition;



    private void OnStart()
    {
        tiles = new Tiles[tilesSizeHorizontalLenght][];
        for(int i = 0; i < tilesSizeHorizontalLenght; i++)
        {
            tiles[i] = new Tiles[tilesSizeVerticalLenght];
        }
        initializeRoutTiles();
    }
    
    private void initializeRoutTiles()
    {
        for(int i = 0; i < tilesSizeHorizontalLenght; i++)
        {
            for(int j = 0; j < tilesSizeVerticalLenght; j++)
            {
                initializeActualTile(i, j);
            }
        }
        }
    
    private void initializeActualTile(int i,int j)
    {
        
    }
}
[System.Serializable]
public class BoolRow
{
    public bool[] row;
}

