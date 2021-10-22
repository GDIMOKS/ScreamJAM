using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int countColler;
    public string weaponName;
    WeaponChanger wc;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            wc = other.GetComponent<WeaponChanger>();
            switch(weaponName)
            {
                case "pistol":
                    TakeAmmo(wc.weapons[0]);
                    break;

                case "shotgun":
                    TakeAmmo(wc.weapons[1]);
                    break;

                case "grenlauncher":
                    TakeAmmo(wc.weapons[2]);
                    break;

                case "autorifle":
                    TakeAmmo(wc.weapons[3]);
                    break;

                case "flamethrower":
                    TakeAmmo(wc.weapons[4]);
                    break;

            }
        }
    }

    public void TakeAmmo(GameObject wc)
    {
        wc.GetComponent<Shooting>().StartAmmo += wc.GetComponent<Shooting>().ammoInColler * countColler;
        Destroy(gameObject);
    }
}
