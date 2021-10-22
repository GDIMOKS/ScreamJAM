using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent nav;
    public Vector3 lastPos;
    public float distance;
    public float Radius;
    public bool freeze = false;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);


        
        if (!freeze && this.GetComponent<EnemyState>().isGrounded)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            
            if (distance > Radius)
            {
                nav.Stop();
            }
            else
            {
                nav.enabled = true;
                nav.SetDestination(player.transform.position);

                if (nav.remainingDistance < nav.stoppingDistance)
                {
                    nav.updateRotation = false;
                    FaceTarget(nav.destination);
                }
                else
                {
                    nav.updateRotation = true;
                }
            }
        }
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 120f);
    }
}
