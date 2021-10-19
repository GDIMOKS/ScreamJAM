using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public Vector3 lastPos;
    public bool isGrounded;
    public bool isStaying;


    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

        lastPos = transform.position;

        if (this.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }
}
