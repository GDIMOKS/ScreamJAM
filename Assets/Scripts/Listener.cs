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
                Patroler patroler = hitCollider.GetComponent<Patroler>();
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();

                if (rb != null && rb.name != "Player")
                {
                    if (rb != null && rb.GetComponent<NavMeshAgent>())
                    {
                        
                        if (!patroler.isGrounded && !patroler.isStaying)
                        {
                            StartCoroutine(WaitingWhileFall(patroler, rb));
                        }
                        else if (patroler.isGrounded)
                        {
                            StartCoroutine(WaitingWhileStay(patroler, rb));
                        }

                        //StartCoroutine(WaitingWhileFall(patroler, rb));
                        //StartCoroutine(WaitingWhileStay(2f, patroler, rb));

                    }
                    //hitCollider.transform.GetComponent<CreatureLife>().EditHP(-Dmg);
                }
            }

            
        }  
    }

    private void LateUpdate()
    {
        //hitColliders = null;
    }

    public IEnumerator WaitingWhileFall(Patroler patroler, Rigidbody rb)
    {   
        yield return new WaitWhile(() => patroler.isGrounded != true);
        
        rb.isKinematic = true;
        patroler.freeze = false;
    }

    public IEnumerator WaitingWhileStay(Patroler patroler, Rigidbody rb)
    {
        yield return new WaitUntil(() => patroler.isStaying == true);

        rb.isKinematic = true;
        patroler.freeze = false;
    }
}
