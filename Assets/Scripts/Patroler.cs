using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroler : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nav;
    public float distance;
    public float Radius;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

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
