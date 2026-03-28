using UnityEngine;

public class CoinPickUp : PickUp
{
    [SerializeField] private int _value = 1;
    [SerializeField] private CoinManager _coinManager;
    protected override void OnPick(GameObject player)
    {
        base.OnPick(player);
        _coinManager.AddCoin(_value);
    }
}
