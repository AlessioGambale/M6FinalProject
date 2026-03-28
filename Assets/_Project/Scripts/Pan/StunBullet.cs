using System.Collections;
using UnityEngine;

public class StunBullet : PoolableObject
{
    [Header("StunBullet Settings")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _altitude;
    [SerializeField] private float _stunDuration;

    private Coroutine _stunCoroutine;
    Rigidbody _rb;
    Collider  _collider;

    public override void OnDespawned()
    {
        if (_stunCoroutine != null )
        {
            StopCoroutine(_stunCoroutine);
            _stunCoroutine = null;
        }
    }
    
    public override void OnSpawned()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void Setup(Vector3 shootDirection)
    {
        _rb = GetComponent<Rigidbody>();

        _rb.velocity = shootDirection * _speed + Vector3.up * _altitude;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Turret")) return;

        _stunCoroutine = StartCoroutine(StunCoroutine(other));
    }

    private IEnumerator StunCoroutine(Collider other)
    {
        _collider = other;

        other.gameObject.SetActive(false);

        SoundManager.Instance.PlayStun();

        yield return new WaitForSeconds(_stunDuration);

        if (_collider != null && _collider.gameObject != null)
        {
            _collider.gameObject.SetActive(true);
        }

        Release();

        _stunCoroutine = null;
    }
}
