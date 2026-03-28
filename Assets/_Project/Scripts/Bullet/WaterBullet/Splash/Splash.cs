using UnityEngine;

public class Splash : PoolableObject
{
    [SerializeField] private float _splashLifeSpan = 5f;
    [SerializeField] Vector3 _offset;
    [SerializeField] private PoolType _poolType;

    private float _lifeStartTime;
    private bool IsLifeFinished() => Time.time - _lifeStartTime >= _splashLifeSpan;

    private void Update()
    {
        if (IsLifeFinished())
        {
            Release();
            return;
        }
    }

    public void SpawnSplash(ContactPoint contactPoint)
    {
        Vector3 splashPosition = contactPoint.point + _offset;

        //Instantiate(gameObject, splashPosition, Quaternion.LookRotation(-contactPoint.normal));

        ObjectPool bulletPool = PoolManager.Instance.GetPool(_poolType);
        PoolableObject obj = bulletPool.GetObject();
        obj.transform.position = splashPosition;
        obj.transform.rotation = Quaternion.LookRotation(-contactPoint.normal);
    }

    public override void OnSpawned()
    {
       _lifeStartTime = Time.time;
    }

    public override void OnDespawned() { }
}
