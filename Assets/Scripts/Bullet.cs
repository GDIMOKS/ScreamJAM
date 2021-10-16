using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int Dmg;
    public float lifeTime;
    float currentTime = 0f;

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
            
            if (hit.transform.GetComponent<CreatureLife>())
            {
                hit.transform.GetComponent<CreatureLife>().EditHP(-Dmg);
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
