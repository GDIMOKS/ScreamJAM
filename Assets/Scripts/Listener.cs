using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Listener : MonoBehaviour
{
    public Collider[] hitColliders;

    void FixedUpdate()
    {

        if (hitColliders != null)
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider != null)
                {
                    Enemy enemy;
                    Rigidbody rb;
                    EnemyState enstate;
                    hitCollider.TryGetComponent<Enemy>(out enemy);
                    hitCollider.TryGetComponent<Rigidbody>(out rb);
                    hitCollider.TryGetComponent<EnemyState>(out enstate);
                    if (hitCollider.TryGetComponent<Rigidbody>(out rb) && hitCollider.TryGetComponent<Enemy>(out enemy) && hitCollider.TryGetComponent<EnemyState>(out enstate))
                    {
                        if (rb != null && rb.name != "Player")
                        {
                            if (rb != null && rb.GetComponent<NavMeshAgent>())
                            {

                                if (!enstate.isGrounded && !enstate.isStaying)
                                {
                                    StartCoroutine(WaitingWhileFall(rb));
                                }
                                else if (enstate.isGrounded)
                                {
                                    StartCoroutine(WaitingWhileStay(rb));
                                }
                                else if (!enstate.isGrounded && enstate.isStaying)
                                {
                                    StartCoroutine(WaitingWhileStatic(rb));
                                }
                            }
                        }
                    }
                }
            }
        }  
    }

    public IEnumerator WaitingWhileStatic(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.5f);
        //rb.isKinematic = false;
    }

    public IEnumerator WaitingWhileFall(Rigidbody rb)
    {
        EnemyState enstate = rb.GetComponent<EnemyState>();
        Enemy enemy = rb.GetComponent<Enemy>();
        yield return new WaitWhile(() => enstate.isGrounded != true);

        if (enemy != null)
        {
            enemy.enabled = true;
        }
        
        //rb.isKinematic = true;
        //patroler.freeze = false;
        
    }

    public IEnumerator WaitingWhileStay(Rigidbody rb)
    {
        EnemyState enstate = rb.GetComponent<EnemyState>();
        Enemy enemy = rb.GetComponent<Enemy>();
        yield return new WaitUntil(() => enstate.isStaying == true);

        if (enemy != null)
        {
            enemy.enabled = true;
        }
        //rb.isKinematic = true;
        //patroler.freeze = false;

    }
}
