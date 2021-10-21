using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public int Dmg;
    [HideInInspector]
    public float lifeTime;


    private float currentTime = 0f;

    private Rigidbody rg;
    private Vector3 LastPos;
    private void Start()
    {
        LastPos = this.transform.position;
        rg = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rg.velocity = transform.TransformDirection(Vector3.forward) * Speed * 10 * Time.fixedDeltaTime;
        RaycastHit hit;
        if (Physics.Linecast(LastPos, this.transform.position, out hit))
        {
            Debug.Log(hit.transform.name);
            
            if (hit.transform.GetComponent<CreatureLife>() && hit.transform.name != "Player")
            {
                hit.transform.GetComponent<CreatureLife>().EditHP(-Dmg);
            }
            else if (hit.transform.name == "Player")
            {
                hit.transform.GetComponent<PlayerLife>().EditHP(-(Dmg / 25));
            }

            Destroy(this.gameObject);
        }
        if (Physics.Linecast(this.transform.position, LastPos, out hit))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.GetComponent<CreatureLife>() && hit.transform.name != "Player")
            {
                hit.transform.GetComponent<CreatureLife>().EditHP(-Dmg);
            }
            else if (hit.transform.name == "Player")
            {
                hit.transform.GetComponent<PlayerLife>().EditHP(-(Dmg / 5));
            }

            Destroy(this.gameObject);
        }
        LastPos = transform.position;

        currentTime += Time.fixedDeltaTime;
        if (currentTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
