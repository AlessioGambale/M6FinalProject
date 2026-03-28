using UnityEngine;

public class TurretStun : MonoBehaviour
{
    [SerializeField] private PoolType _poolType;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _firePoint;

    private void InstantiateBullet()
    {
        Vector3 direction = (_target.position - _firePoint.position).normalized;
        ObjectPool bulletPool = PoolManager.Instance.GetPool(_poolType);
        PoolableObject obj = bulletPool.GetObject();
        StunBullet clone = obj as StunBullet;
        clone.transform.position = _firePoint.position;
        clone.transform.rotation = _firePoint.rotation;
        clone.Setup(direction);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;   
        InstantiateBullet();
        gameObject.GetComponent<Collider>().enabled = false;
        SoundManager.Instance.PlayPan();
    }
}
