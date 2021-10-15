using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroler : MonoBehaviour
{
    //public float speed;
    //public int positionOfPatrol;
    //public Transform point;
    //bool movingRight = true;
    //bool movingForward;

    //public float stoppingDistance;
    //Rigidbody rb = new Rigidbody();

    GameObject player;
    NavMeshAgent nav;
    public float distance;
    public float Radius;

    //bool chill = false;
    //bool angry = false;
    //bool goBack = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = gameObject.GetComponent<NavMeshAgent>();
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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

        /*
        if (Vector3.Distance(transform.position, point.position) < positionOfPatrol && !angry)
        {
            chill = true;
        }

        if (Vector3.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill)
        {
            Chill();
        }
        if (angry)
        {
            Angry();
        }
        if (goBack)
        {
            GoBack();
        }*/

    }

    void Chill()
    {
        /*
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x + positionOfPatrol)
        {
            movingRight = true;
        }
        
        if (!movingRight)
        {
            //transform.position = new Vector3(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            rb.AddForce(new Vector3(transform.position.x + speed * Time.fixedDeltaTime, 0, 0) - new Vector3(rb.velocity.x, 0, rb.velocity.z), ForceMode.VelocityChange);//(transform.TransformDirection(new Vector3(transform.position.x + speed * Time.fixedDeltaTime, 0, transform.position.z).normalized) - new Vector3(rb.velocity.x, 0, rb.velocity.z), ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(new Vector3(transform.position.x - speed * Time.fixedDeltaTime, 0, 0) - new Vector3(rb.velocity.x, 0, rb.velocity.z), ForceMode.VelocityChange);
            //transform.position = new Vector3(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            //rb.AddForce(transform.TransformDirection(new Vector3(transform.position.x - speed * Time.fixedDeltaTime, 0, transform.position.z).normalized) - new Vector3(rb.velocity.x, 0, rb.velocity.z), ForceMode.VelocityChange);
        }

        /*
        if (transform.position.z > point.position.z + positionOfPatrol)
        {
            movingForward = false;
        }
        else if (transform.position.z < point.position.z + positionOfPatrol)
        {
            movingForward = true;
        }

        if (movingForward)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z + speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z - speed * Time.fixedDeltaTime);
        }*/
    }
    /*
    void Angry()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
    }

    void GoBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.fixedDeltaTime);
    }*/
}
