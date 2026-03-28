using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] private float _splashLifeSpan = 5f;
    [SerializeField] Vector3 _offset;
    private void Start()
    {
        Destroy(gameObject,_splashLifeSpan);
    }
    public void SpawnSplash(ContactPoint contactPoint)
    {
        Vector3 splashPosition = contactPoint.point + _offset;
        Instantiate(gameObject, splashPosition, Quaternion.LookRotation(-contactPoint.normal));
    }
}
