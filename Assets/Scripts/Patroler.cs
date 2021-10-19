using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroler : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nav;
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
                nav.enabled = false;
            }
            else
            {
                nav.enabled = true;
                nav.SetDestination(player.transform.position);
            }
        }
    }
}
