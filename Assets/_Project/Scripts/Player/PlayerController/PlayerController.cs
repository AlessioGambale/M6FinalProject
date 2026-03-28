using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private int _maxJumps;
    [SerializeField] private GroundCheck _grcheck;

    [Header("Move Settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 5f;

    [SerializeField] private CameraOrbit _camera;

    [SerializeField] private SoundManager _soundManager;
    private int _jumpCount;

    private float _speedMultiplier = 1;
    private float _h;
    private float _v;

    private bool _space;
    private bool _shift;
    private bool _canRun = true;
    private bool _canMove = true;

    private Rigidbody _rb;
    private Vector3 _inputDir;
    private AnimationParamHandler _animController;
    

   
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animController = GetComponent<AnimationParamHandler>();
    }
    
    private void HandleInput()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        _space = Input.GetKeyDown(KeyCode.Space);
        _shift = Input.GetKey(KeyCode.LeftShift);
        _inputDir = new Vector3(_h, 0f, _v).normalized;
        _animController.SetForward(_inputDir.magnitude);
        _inputDir = _camera.ConvertInputToCameraDirection(_inputDir);
    }
    public void CanRun (bool canRun)
    {
        _canRun = canRun;
    }

    public void StopMoving()
    {
        _canMove = false;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
    public void RestartMoving()
    {
        _canMove = true;
    }
    private void MoveAndRotate()
    {
        _rb.MoveRotation(RotateTargetTowardsCamera(_inputDir));
        float currentSpeed = _speed * _speedMultiplier;
        Vector3 velocity = _inputDir * currentSpeed;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }

    public void ResetMoveAndRotate()
    {
        _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        _rb.angularVelocity = Vector3.zero;
    }
    private void FixedUpdate()
    {
        if (!_canMove) return;
        if (_inputDir != Vector3.zero)
        {
            MoveAndRotate();
        }
        else
        {
            ResetMoveAndRotate();
        }
        if (_rb.velocity.y <0f)
        {
            _rb.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1f) * Time.fixedDeltaTime;
        }
    }
    private void IsRunning()
    {
        if (_shift)
        {
            SetSpeedMultiplier(2);
        }
        else
        {
            ResetSpeedMultiplier();
        }
    }
    private void Update()
    {
        
        if (!_canMove) return;

        HandleInput();

        if (_space) IsJumping();
        
        if (_canRun) 
        {
            IsRunning();
        }
        else
        {
            ResetSpeedMultiplier();
        }
        
    }
    public void SetSpeedMultiplier(float speedMultiplier)
    {
        _speedMultiplier = speedMultiplier;
    }
    public void ResetSpeedMultiplier()
    {
        SetSpeedMultiplier(1);
    }
    private void IsJumping()
    {
        if (_grcheck._isGrounded)
        {
            _jumpCount = 0;

        }
        if (!_grcheck._isGrounded && _jumpCount == 0) return;
        if (_jumpCount >= _maxJumps) return;
        _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce , _rb.velocity.z);
        _jumpCount++;
        _soundManager.PlayJump();
    }
    public Quaternion RotateTargetTowardsCamera(Vector3 input)
    {
        Quaternion targetRotation = Quaternion.LookRotation(input);
        return Quaternion.Slerp(_rb.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
