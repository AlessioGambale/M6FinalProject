using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private CheckPointManager _checkPointManager;
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))return;
        _checkPointManager.SetCheckPoint(transform.position);
    }
}
