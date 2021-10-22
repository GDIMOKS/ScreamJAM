using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int Dmg;
    Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(this.transform.position, this.transform.position + transform.TransformDirection(Vector3.forward * 2f), out hit))
        {

            if (hit.transform.CompareTag("Player"))
            {
                anim.SetTrigger("Attack");
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CreatureLife crl;
        PlayerLife pl;
        if (other.TryGetComponent<CreatureLife>(out crl) && !other.transform.CompareTag("Player"))
        {
            crl.EditHP(-Dmg);
        }

        if (other.TryGetComponent<PlayerLife>(out pl) && other.transform.CompareTag("Player"))
        {
            pl.EditHP(-Dmg);
        }
    }
}
