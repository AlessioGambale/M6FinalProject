using UnityEngine;

public class PushTrap : MonoBehaviour
{
    [SerializeField] float _pushForce;
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!other.TryGetComponent<Rigidbody>(out var rb)) return;
        rb.AddForce(transform.forward * _pushForce, ForceMode.Acceleration);
    }
}
