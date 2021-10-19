using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrenBulletAlt : MonoBehaviour
{
    public float Speed;
    public int Dmg;
    public float lifeTime;
    public float radius;
    private float currentTime = 0f;

    private Rigidbody rg;
    private Vector3 LastPos;
    private void Start()
    {
        LastPos = this.transform.position;
        rg = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rg.velocity = transform.TransformDirection(Vector3.forward) * Speed * 10 * Time.fixedDeltaTime;

        RaycastHit hit;

        if (Physics.Linecast(LastPos, this.transform.position, out hit))
        {
            Debug.Log(hit.transform.name);

            ExplosionDamage(hit.point, radius);

            Destroy(this.gameObject);
        }

        LastPos = transform.position;

        currentTime += Time.fixedDeltaTime;
        if (currentTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        GameObject go = GameObject.Find("ListenerObj");
        go.GetComponent<Listener>().hitColliders = hitColliders;

        foreach (var hitCollider in hitColliders)
        {
            Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
            
            if (rb != null && rb.name != "Player")
            {
                if (rb.GetComponent<NavMeshAgent>())
                {
                    Patroler patroler = rb.GetComponent<Patroler>();
                    rb.isKinematic = false;
                    rb.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    patroler.freeze = true;
                    rb.AddExplosionForce(550f, center, radius);//, 3.0f);
                }

                //hitCollider.transform.GetComponent<CreatureLife>().EditHP(-Dmg); 
            }
        }

        Destroy(this.gameObject);
    }

    
}
