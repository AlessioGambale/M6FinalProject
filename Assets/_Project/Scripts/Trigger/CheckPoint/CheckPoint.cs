using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))return;
        CheckPointManager.Instance.SetCheckPoint(transform.position);
    }
}
