using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("111");
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        CreatureLife crl;
        //Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        while (i < numCollisionEvents)
        {
            if (other.TryGetComponent<CreatureLife>(out crl))
            {
                crl.EditHP(-1);
            }
            i++;
        }
    }
}
