using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;


public class CurrencyManager : MonoBehaviour
{
   [SerializeField]int playerCurrency = 100;
   [SerializeField] TMP_Text textContainer;

    void Start()
    {
        CurrencyEvents.OnEnemyKilled += HandleEnemyKilled;
        
    }

    private void HandleEnemyKilled(Enemy enemy)
    {
        playerCurrency += enemy.GetReward();
        Debug.Log("Player Currency: " + playerCurrency);
    }
    public bool TrySpend(int cost)
    {
        if (playerCurrency >= cost)
        {
            playerCurrency -= cost;
            return true;
        }
        return false;
    }
    private void OnDestroy()
    {
        CurrencyEvents.OnEnemyKilled -= HandleEnemyKilled;
    }
    private void Update()
    {
        textContainer.text = playerCurrency.ToString();
    }
}
