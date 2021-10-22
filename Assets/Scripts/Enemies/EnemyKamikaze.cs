using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    private Vector3 LastPos;
    public int Dmg;
    public float radius;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        rb.AddRelativeForce(Vector3.forward * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ExplosionDamage(collision.transform.position, radius);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            Rigidbody rb;
            PlayerLife pl;
            if (hitCollider.TryGetComponent<Rigidbody>(out rb))
            {
                if (rb != null && rb.CompareTag("Player") && hitCollider.TryGetComponent<PlayerLife>(out pl))
                {
                    rb.AddExplosionForce(400f, center, radius, 3.0f);
                    pl.EditHP(-Dmg);
                }
            }
        }
        hitColliders = null;
        Destroy(this.gameObject);
    }
}
