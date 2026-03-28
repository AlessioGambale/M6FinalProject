using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shoot Settings")]
    [SerializeField] protected private float _damage = 10;
    [SerializeField] protected private float _fireRate = 0f;

    [Header("References")]
    [SerializeField] protected private DetectionRange _range;
    [SerializeField] protected private Bullet _bullet;
    [SerializeField] protected private Transform [] _shootPoint;

    [Header("RayCast Settings")]
    [SerializeField] protected private float _radius = 0.5f;
    [SerializeField] protected private float _fireRange = 10f;
    [SerializeField] protected private LayerMask _layerMask;

    [SerializeField] SoundManager _soundManager;
    
    
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
                Bullet clone = Instantiate(_bullet, shoot.position, shoot.rotation);
                clone.Setup(direction , _damage);
                _soundManager.PlayShoot();
            }
        }
        
    }
}