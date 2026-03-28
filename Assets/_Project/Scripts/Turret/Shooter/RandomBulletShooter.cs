using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletShooter : Shooter
{
    [SerializeField] private Bullet[] _bullets; 
    private int _currentIndex;

    protected override void SphereCastShoot()
    {
        foreach (var shoot in _shootPoint)
        {
            Vector3 direction = (_range.Target.position - shoot.position).normalized;

            Debug.DrawRay(shoot.position, direction * _fireRange, Color.blue, _fireRate);

            if (Physics.SphereCast(shoot.position, _radius, direction, out RaycastHit hitInfo, _fireRange, _layerMask))
            {
                IstantiateRandomBullet(direction, shoot);
            }
        }
    }
    private void IstantiateRandomBullet(Vector3 dir , Transform shoot)
    {
        _currentIndex = Random.Range(0, _bullets.Length);
        Bullet bulletClone = Instantiate(_bullets[_currentIndex], shoot.position, shoot.rotation);
        bulletClone.Setup(dir, _damage);
    }
}

    
