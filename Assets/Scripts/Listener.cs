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
                    Patroler patroler;
                    Rigidbody rb;
                    EnemyState enstate;
                    hitCollider.TryGetComponent<Patroler>(out patroler);
                    hitCollider.TryGetComponent<Rigidbody>(out rb);
                    hitCollider.TryGetComponent<EnemyState>(out enstate);
                    if (hitCollider.TryGetComponent<Rigidbody>(out rb) && hitCollider.TryGetComponent<Patroler>(out patroler) && hitCollider.TryGetComponent<EnemyState>(out enstate))
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
        Patroler patroler = rb.GetComponent<Patroler>();
        yield return new WaitWhile(() => enstate.isGrounded != true);

        if (patroler != null)
        {
            patroler.enabled = true;
        }
        
        //rb.isKinematic = true;
        //patroler.freeze = false;
        
    }

    public IEnumerator WaitingWhileStay(Rigidbody rb)
    {
        EnemyState enstate = rb.GetComponent<EnemyState>();
        Patroler patroler = rb.GetComponent<Patroler>();
        yield return new WaitUntil(() => enstate.isStaying == true);

        if (patroler != null)
        {
            patroler.enabled = true;
        }
        //rb.isKinematic = true;
        //patroler.freeze = false;

    }
}
