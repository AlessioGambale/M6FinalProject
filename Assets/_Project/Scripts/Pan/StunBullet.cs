using UnityEngine;

public class StunBullet : MonoBehaviour
{
    [Header("StunBullet Settings")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 5f;
    [SerializeField] private float _altitude;
    [SerializeField] private float _stunDuration;

    private float _stunStartTime;
    Rigidbody _rb;
    Collider  _collider;
    private bool _isStun = false;
    public void Setup(Vector3 shootDirection)
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, _lifetime);
        _rb.velocity = shootDirection * _speed + Vector3.up * _altitude;
    }
    private bool IsStunEnded() => Time.time - _stunStartTime >= _stunDuration;
    private void ApplyStun(Collider other)
    {
        _collider = other;
        other.gameObject.SetActive(false);
        _stunStartTime = Time.time;
        _isStun = true;
    }
    private void Update()
    {
        if (!_isStun) return;
        if (!IsStunEnded()) return;
        _collider.gameObject.SetActive(true);
        _isStun = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Turret")) return;
        ApplyStun(other); 
        Destroy(gameObject , _stunDuration);
        SoundManager.Instance.PlayStun();
    }
}
