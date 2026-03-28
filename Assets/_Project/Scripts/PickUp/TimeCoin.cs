using UnityEngine;

public class TimeCoin : PickUp
{
    [SerializeField] private int _timeValue = 1 ;

    protected override void OnPick(GameObject player)
    {
        base.OnPick(player);
        TimeManager.Instance.AddTime(_timeValue);
    }
}
