using UnityEngine;

public class HealPickUp : PickUp
{
    [SerializeField] private int _healAmount = 10;
   protected override void OnPick(GameObject player)
    {
        base.OnPick(player);
        var LifeController = player.GetComponent<LifeController>();

        if (LifeController != null)
        {
            LifeController.AddHp(_healAmount);
        }
    }
}
