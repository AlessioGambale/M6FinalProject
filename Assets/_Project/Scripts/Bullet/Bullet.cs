using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 5f;

    private float _damage = 10;
    Rigidbody _rb;

    public void Setup(Vector3 shootDirection, float damage)
    {
        _rb = GetComponent<Rigidbody>();
        _damage = damage;
        Destroy(gameObject, _lifetime);
        _rb.velocity = shootDirection * _speed;
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.TryGetComponent<LifeController>(out var lifeController))
            {
                lifeController.TakeDamage(_damage);
            }
        }
    }

}
