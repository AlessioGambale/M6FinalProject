using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shoot Settings")]
    [SerializeField] protected float _damage = 10;
    [SerializeField] protected float _fireRate = 0f;

    [Header("References")]
    [SerializeField] protected DetectionRange _range;
    [SerializeField] protected PoolType _poolType;
    [SerializeField] protected Transform [] _shootPoint;

    [Header("RayCast Settings")]
    [SerializeField] protected float _radius = 0.5f;
    [SerializeField] protected float _fireRange = 10f;
    [SerializeField] protected LayerMask _layerMask;

    protected private float _lastShoot = 0f;

    protected virtual void Update()
    {
        ShootOnTarget();
    }

    protected private void ShootOnTarget()
    {
        if (_range.Target == null) return;

        if (IfShoot())
        {
            SphereCastShoot();
            _lastShoot = Time.time;
        }
    }

    private bool IfShoot()
    {
        return Time.time - _lastShoot >= _fireRate;
    }

    protected virtual void SphereCastShoot()
    {
        foreach (var shoot in _shootPoint)
        {
            Vector3 direction = (_range.Target.position - shoot.position).normalized;

            Debug.DrawRay(shoot.position, direction * _fireRange, Color.blue, _fireRate);

            if (Physics.SphereCast(shoot.position, _radius, direction, out RaycastHit hitInfo, _fireRange, _layerMask))
            {
                ObjectPool bulletPool = PoolManager.Instance.GetPool(_poolType);
                PoolableObject obj = bulletPool.GetObject();
                Bullet clone = obj as Bullet;
                clone.transform.position = shoot.position;
                clone.transform.rotation = shoot.rotation;
                clone.Setup(direction , _damage);
                SoundManager.Instance.PlayShoot();
            }
        }
        
    }
}