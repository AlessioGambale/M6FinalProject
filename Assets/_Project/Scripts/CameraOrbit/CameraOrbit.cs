using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _rotationSpeed = 2f;

    [Header("Pitch Settings")]
    [SerializeField] private float _minYAngle = -10f;
    [SerializeField] private float _maxYAngle = 30f;

    [SerializeField] private UIManager _UIManager;
    
    private float _pitch;
    private float _yaw;

    private void Start()
    {
        LockMouse();
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public Vector3 ConvertInputToCameraDirection(Vector3 input)
    {
        Vector3 cameraForward = transform.forward;
        Vector3 cameraRight = transform.right;

        Vector3 moveDir = cameraForward * input.z + cameraRight * input.x;
        moveDir.y = 0;

        moveDir = Vector3.ClampMagnitude(moveDir, 1f);

        return moveDir;
    }
    private void LateUpdate()
    {
        if (_UIManager.IsUIOpen) return;
        if (_target == null) return;

        _yaw += Input.GetAxis("Mouse X") * _rotationSpeed;
        _pitch -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        _pitch = Mathf.Clamp(_pitch, _minYAngle, _maxYAngle);

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
        Vector3 desideredPosition = _target.position + rotation * _offset;

        Vector3 lookAt = _target.position + Vector3.up * 2;
        Quaternion lookRotation = Quaternion.LookRotation(lookAt - desideredPosition);
        transform.SetPositionAndRotation(desideredPosition, lookRotation);
    }
}
