using System;
using TMPro;
using UnityEngine;


public class CurrencyManager : MonoBehaviour
{
   
   [SerializeField] TMP_Text textContainer;

    void Start()
    {
        CurrencyEvents.OnEnemyKilled += HandleEnemyKilled;
        textContainer.text = playerCurrency.ToString();
    }
    public static CurrencyManager Instance { get; private set; }
    public event Action<int> OnCurrencyChanged;

    [SerializeField] int playerCurrency = 100;

    private void Awake() => Instance = this;

    public bool TrySpend(int cost) {
        if (playerCurrency >= cost) {
            playerCurrency -= cost;
            OnCurrencyChanged?.Invoke(playerCurrency);
            return true;
        }
        return false;
    }

    public void AddCurrency(int amount) {
        playerCurrency += amount;
        OnCurrencyChanged?.Invoke(playerCurrency);
    }

    private void HandleEnemyKilled(Enemy enemy)
    {
        playerCurrency += enemy.GetReward();
        Debug.Log("Player Currency: " + playerCurrency);
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
