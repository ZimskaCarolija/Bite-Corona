using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KrvSplashKod : MonoBehaviour
{
    public GameObject Krv;
    public List<ParticleCollisionEvent> CollisionEvents = new List<ParticleCollisionEvent>();
    public ParticleSystem ParticleSystem;
    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {
        Debug.LogError(other.name);
        ParticlePhysicsExtensions.GetCollisionEvents(ParticleSystem, other, CollisionEvents);
        for(int i = 0;i< CollisionEvents.Count; i++)
        {
            Instantiate(Krv, CollisionEvents[i].intersection,Quaternion.identity);
        }
    }
}
