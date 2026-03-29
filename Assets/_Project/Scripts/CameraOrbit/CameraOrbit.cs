using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

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
        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRight = _camera.transform.right;

        Vector3 moveDir = cameraForward * input.z + cameraRight * input.x;
        moveDir.y = 0;

        if (moveDir.magnitude > 0.01f) moveDir.Normalize();

        return moveDir;
    }
    
}
