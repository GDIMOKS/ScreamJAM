using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Physics.Linecast(this.transform.position, LastPos, out hit))
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
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform.GetComponent<CreatureLife>())
            {
                hitCollider.transform.GetComponent<CreatureLife>().EditHP(-Dmg);
                hitCollider.GetComponent<Rigidbody>().AddForce((hitCollider.transform.position - center) * 300, ForceMode.Impulse);
                
            }   
        }
        Destroy(gameObject);
    }
}
