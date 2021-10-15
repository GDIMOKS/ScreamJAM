using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;
    public int Dmg;

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
            /*TODO:
            if (hit.—юда код в котором будет хп надо засунуть)
                —нижаем хп на Dmg(функци€ должна быть внутри кода с хп)
            */
            Destroy(this.gameObject);
        }
        LastPos = transform.position;
    }
}
