using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        if (!collision.collider.TryGetComponent<Rigidbody>(out var rb)) return;
        rb.AddForce(transform.up * _bounceForce, ForceMode.Impulse);
        SoundManager.Instance.PlayBalloon();
    }
}

