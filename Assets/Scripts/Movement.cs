using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb = new Rigidbody();
    public float speed;
    public float currentSpeed;
    public float sprintSpeed;
    
    public float jumpForce;
    public bool isGrounded;
    //public float currentJumpForce;
    //public float speedJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        currentSpeed = speed;
        sprintSpeed = currentSpeed * 2;

        //currentJumpForce = jumpForce;
        //speedJumpForce = currentJumpForce * 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");
        //float sprint = Input.GetAxis("Fire3");
        if (Input.GetButton("Fire3") && isGrounded)
        {
            currentSpeed = sprintSpeed;
            //currentJumpForce = speedJumpForce;
        }
        else
        {
            currentSpeed = speed;
            //currentJumpForce = jumpForce;
        }

        if (isGrounded)
        {
            rb.AddForce(transform.TransformDirection(new Vector3(horMove, 0, verMove).normalized * currentSpeed * Time.fixedDeltaTime) - new Vector3(rb.velocity.x, 0, rb.velocity.z), ForceMode.VelocityChange);
        }

        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .6f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
