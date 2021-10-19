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
    public bool isGrounded;
    public bool isStaying;
    

    void Start()
    {
        lastPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distanceFromPlane = .51f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distanceFromPlane))
        {
            //Debug.DrawRay(origin, direction * distanceFromPlane, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (transform.position == lastPos)
        {
            isStaying = true;
        }
        else
        {
            isStaying = false;
        }
        
        if (!freeze && isGrounded)
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

        lastPos = transform.position;

        if (this.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }

        
    }

    /*
    public IEnumerator Freezing(float _time, bool freeze)
    {
        yield return new WaitForSeconds(_time);
        freeze = false;
    }*/
}
