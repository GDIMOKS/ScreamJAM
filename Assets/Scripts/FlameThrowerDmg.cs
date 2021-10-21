using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerDmg : MonoBehaviour
{
    public int Dmg;
    private void OnTriggerStay(Collider other)
    {
        CreatureLife crl;
        PlayerLife pl;
        if(other.TryGetComponent<CreatureLife>(out crl) && !other.transform.CompareTag("Player"))
        {
            crl.EditHP(-Dmg);
        }

        if (other.TryGetComponent<PlayerLife>(out pl) && other.transform.CompareTag("Player"))
        {
            pl.EditHP(-Dmg);
        }
    }
}
