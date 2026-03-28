using UnityEngine;

public class TimeCoin : PickUp
{
    [SerializeField] private int _timeValue = 1 ;
    [SerializeField] private TimeManager _timeManager;
    protected override void OnPick(GameObject player)
    {
        base.OnPick(player);
        _timeManager.AddTime(_timeValue);
    }
}
