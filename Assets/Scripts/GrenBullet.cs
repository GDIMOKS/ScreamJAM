using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenBullet : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public int Dmg;
    [HideInInspector]
    public float lifeTime;

    private float currentTime = 0f;
    private Rigidbody rb;
    private bool manyBullets = true;
    private GameObject gb;
    private Vector3 LastPos;
    public float radius;
    public int cntBullets;
    public GameObject Explosion;


    private void Start()
    {
        LastPos = this.transform.position;
        rb = GetComponent<Rigidbody>();

        if (!manyBullets)
        {
            rb.gameObject.GetComponent<GrenBullet>().Speed /= 5;
            rb.GetComponent<GrenBullet>().Dmg /= cntBullets;
            rb.GetComponent<Transform>().localScale = new Vector3(0.175f, 0.175f, 0.175f);
            rb.GetComponent<GrenBullet>().radius /= 2;
        }
        rb.AddRelativeForce(Vector3.forward * Speed, ForceMode.Impulse);

    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Linecast(LastPos, this.transform.position, out hit))
        {
            CreatureLife crl;
            Debug.Log(hit.transform.name);
            Instantiate(Explosion, transform.position, transform.rotation);
            
            if (hit.transform.TryGetComponent<CreatureLife>(out crl))
            {
                crl.EditHP(-Dmg);
                Destroy(this.gameObject);
            }
            else
            {
                ExplosionDamage(this.transform.position, radius);

                if (manyBullets)
                {
                    FireWorks(hit);

                    Destroy(gameObject);
                }
                else
                {
                    ExplosionDamage(this.transform.position, radius);
                }
            }
        }

        LastPos = transform.position;

        currentTime += Time.fixedDeltaTime;

        if (currentTime >= lifeTime)
        {
            Destroy(gameObject);
            currentTime = 0;
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
            }
            if (!manyBullets)
            {
                Debug.Log(gameObject.name + " задел " + hitCollider.name);
                Destroy(this.gameObject);
            }
        }
    }

    public void FireWorks(RaycastHit hit)
    {
        Quaternion angle = new Quaternion();

        manyBullets = false;

        for (int i = 0; i < cntBullets; i++)
        {
            gb = Instantiate<GameObject>(rb.gameObject, hit.point, angle);
            gb.GetComponent<GrenBullet>().manyBullets = false;
            gb.transform.LookAt(hit.point + hit.normal + new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f), Random.Range(-1f, 1f)));
            gb.transform.position = hit.point;
        }
    }

    public IEnumerator WaitTillShoot(float _time)
    {
        yield return new WaitForSeconds(_time);
        Destroy(this.gameObject);
    }
}
