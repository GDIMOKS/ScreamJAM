using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenBullet : MonoBehaviour
{
    public float Speed;
    public int Dmg;
    public float lifeTime;
    float currentTime = 0f;
    private Rigidbody rb;
    public bool manyBullets = true;
    public GameObject gb;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * Speed, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime >= lifeTime)
        {
            Destroy(gameObject);
            currentTime = 0;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.transform.GetComponent<CreatureLife>())
        {
            collision.gameObject.transform.GetComponent<CreatureLife>().EditHP(-Dmg);
            Debug.Log(gameObject.GetComponent<GrenBullet>().Dmg);
            Destroy(gameObject);            
        }
        else
        {
            if (manyBullets)
            {
                Quaternion angle = new Quaternion();
                manyBullets = false;

                for (int i = 0; i < 10; i++)
                {
                    angle.eulerAngles = rb.rotation.eulerAngles + new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
                    //rb.gameObject.GetComponent<GrenBullet>().Speed = Speed / 100;
                    gb = Instantiate<GameObject>(rb.gameObject, rb.position, angle);
                    gb.GetComponent<GrenBullet>().Dmg = 50;
                    //gb.GetComponent<Rigidbody>().mass = 5;
                    gb.GetComponent<Transform>().localScale = new Vector3(0.175f, 0.175f, 0.175f);
                    //gb.GetComponent<GrenBullet>().Speed = 5;
                    //gb.GetComponent<GrenBullet>().Speed = Speed / 100;
                }
            }
        }
    }
}
