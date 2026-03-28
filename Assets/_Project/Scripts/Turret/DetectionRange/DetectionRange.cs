using UnityEngine;

public class DetectionRange : MonoBehaviour
{
    public Transform Target { get; private set;}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Target = collision.transform;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Target = null;
        }
    }
}
