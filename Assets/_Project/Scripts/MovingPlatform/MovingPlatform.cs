using UnityEngine;

public abstract class MovingPlatform : MonoBehaviour
{
    [SerializeField] protected bool _setPlatformParent;
    [SerializeField] protected float _speed;

    protected bool _hasPlayer;

    protected abstract void Move();
    protected virtual void FixedUpdate()
    {
       Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_setPlatformParent) return;
        if (!other.gameObject.CompareTag("Player")) return;
        _hasPlayer = true;
        other.gameObject.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!_setPlatformParent) return;
        if (!other.gameObject.CompareTag("Player")) return;
        _hasPlayer = false;
        other.gameObject.transform.SetParent(null);
    }
}
