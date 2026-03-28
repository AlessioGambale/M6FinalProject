using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathDamage : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private float _time;
    private float _timer;

    private bool DealDamage() => Time.time - _timer >= _time;
    private void Update()
    {
        if (DealDamage())
        {
            _time = Time.time;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.TryGetComponent<LifeController>(out var lifeController)) return;
        if (!DealDamage()) return;
        lifeController.TakeDamage(_damageAmount);
    }

}
