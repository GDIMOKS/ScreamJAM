using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineWeapon : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyMag());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
    public IEnumerator DestroyMag()//ћожно тоже через анимацию оружи€ и ивент в ней
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
