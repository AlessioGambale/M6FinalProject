using UnityEngine;

public class TurretStun : MonoBehaviour
{
    [SerializeField] StunBullet _bulletPrefab;
    [SerializeField] Transform _target;
    [SerializeField] Transform _firePoint;

    [SerializeField] private SoundManager _soundManager;
    private void InstantiateBullet()
    {
        Vector3 direction = (_target.position - _firePoint.position).normalized;
        StunBullet bulletClone = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bulletClone.Setup(direction);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;   
        InstantiateBullet();
        gameObject.GetComponent<Collider>().enabled = false;
        _soundManager.PlayPan();
    }
}
