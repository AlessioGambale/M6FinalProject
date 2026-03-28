using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] public bool _isGrounded;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _radius = 1f;

    private void Update()
    {
        _isGrounded = GroundChecker();

    }
    public bool GroundChecker()
    {
        return Physics.CheckSphere(transform.position, _radius, _groundMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
