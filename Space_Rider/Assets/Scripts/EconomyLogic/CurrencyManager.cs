using UnityEngine;


public class CurrencyManager : MonoBehaviour
{
   [SerializeField]int playerCurrency = 100;

    void Start()
    {
        TileEvents.OnTileClicked += HandleTileClicked;
        CurrencyEvents.OnEnemyKilled += HandleEnemyKilled;
        
    }

    private void HandleEnemyKilled(Enemy enemy)
    {
        playerCurrency += enemy.GetReward();
        Debug.Log("Player Currency: " + playerCurrency);
    }
    private void HandleTileClicked(TilesTurret tile)
    {
        if (playerCurrency >= 50)
        {
            playerCurrency -= 50;
            Debug.Log("Torre construida! Player Currency: " + playerCurrency);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para construir esta torre.");
        }
    }
}
