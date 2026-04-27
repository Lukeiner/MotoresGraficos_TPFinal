using UnityEngine;


public class Tiles_Settings : MonoBehaviour
{
    [SerializeField] private Tiles[][] tiles;
    [SerializeField] private int tilesSizeHorizontalLenght;
    [SerializeField] private int tilesSizeVerticalLenght;
    [SerializeField] private Tiles enemyPortalTile;
    [SerializeField] private Tiles baseTile;



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
