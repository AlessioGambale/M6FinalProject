using UnityEngine;

public class Bullet : PoolableObject
{
    [SerializeField] private float _speed = 10f;

    private float _damage = 10;
    Rigidbody _rb;

    public override void OnDespawned() { }

    public override void OnSpawned()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void Setup(Vector3 shootDirection, float damage)
    {
        _rb = GetComponent<Rigidbody>();
        _damage = damage;
       
        _rb.velocity = shootDirection * _speed;
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.TryGetComponent<LifeController>(out var lifeController))
            {
                lifeController.TakeDamage(_damage);
            }
        }
        Release();
    }

}
