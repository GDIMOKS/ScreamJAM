using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerDmg : MonoBehaviour
{
    public int Dmg;
    private void OnTriggerStay(Collider other)
    {
        CreatureLife crl;
        if(other.TryGetComponent<CreatureLife>(out crl))
        {
            crl.EditHP(-Dmg);
        }
    }
}
