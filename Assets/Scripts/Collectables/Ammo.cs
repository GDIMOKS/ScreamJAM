using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject weapon;
    public int countColler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //other.GetComponentInChildren<Shooting>().StartAmmo += other.GetComponentInChildren<Shooting>().ammoInColler * 2;
            weapon.GetComponent<Shooting>().StartAmmo += weapon.GetComponent<Shooting>().ammoInColler * countColler;
            Destroy(gameObject);
        }
    }
}
