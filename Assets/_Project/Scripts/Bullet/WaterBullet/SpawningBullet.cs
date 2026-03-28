using UnityEngine;

public class SpawningBullet : Bullet
{
    
    [SerializeField] private Splash _splash;
   
     protected override void OnCollisionEnter(Collision collision)
     {
        base.OnCollisionEnter(collision);
        if (!collision.collider.CompareTag("Player"))
        {
            ContactPoint contactPoint = collision.contacts[0];
            _splash.SpawnSplash(contactPoint);
        }
     }
}
