using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    [SerializeField] private DetectionRange _range;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _canUseY = false;

    private void RotationToTarget()
    {
        if (_range.Target == null) return;
        Vector3 direction = _range.Target.position - transform.position;
        if (!_canUseY ) direction.y = 0; 
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation , _rotationSpeed * Time.deltaTime);
    }
    private void Update()
    {
        RotationToTarget();
    }
}
