using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> OnCoinsChange;
    public int Coins { get; private set; }
    
    private void SetCoins(int value)
    {
        value = Mathf.Max(value, 0);
        Coins = value;
        OnCoinsChange?.Invoke(Coins);
    }
    public void AddCoin (int amount)
    {
        SetCoins(Coins += amount);
    }
    public bool HasReachedCoins(int requierdCoins) => Coins >= requierdCoins;
}
