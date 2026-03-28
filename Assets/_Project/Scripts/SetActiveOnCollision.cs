using UnityEngine;

public class SetActiveOnCollision : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    [SerializeField] private string _tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            other.gameObject.SetActive(_isActive);
            gameObject.SetActive(_isActive);
        }
    }
}
