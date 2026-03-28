using UnityEngine;

public class RandomBulletShooter : Shooter
{
    [SerializeField] private PoolType[] _poolTypes; 
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
        _currentIndex = Random.Range(0, _poolTypes.Length);
        ObjectPool bulletPool = PoolManager.Instance.GetPool(_poolTypes[_currentIndex]);
        PoolableObject obj = bulletPool.GetObject();
        Bullet clone = obj as Bullet;
        clone.transform.position = shoot.position;
        clone.transform.rotation = shoot.rotation;
        clone.Setup(dir, _damage);
    }
}

    
