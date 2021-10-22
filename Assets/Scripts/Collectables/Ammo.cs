using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //public GameObject weapon;
    public int countColler;
    public string Weapon;
    WeaponChanger wc;
    private void Start()
    {
        //wc[]       
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            wc = other.GetComponent<WeaponChanger>();
            switch(Weapon)
            {
                case "pistol":
                    wc.weapons[0].GetComponent<Shooting>().StartAmmo += wc.weapons[0].GetComponent<Shooting>().ammoInColler * countColler;
                    Destroy(gameObject);
                    break;

                case "shotgun":
                    wc.weapons[1].GetComponent<Shooting>().StartAmmo += wc.weapons[1].GetComponent<Shooting>().ammoInColler * countColler;
                    Destroy(gameObject);
                    break;

                case "grenlauncher":
                    wc.weapons[2].GetComponent<Shooting>().StartAmmo += wc.weapons[2].GetComponent<Shooting>().ammoInColler * countColler;
                    Destroy(gameObject);
                    break;

                case "autorifle":
                    wc.weapons[3].GetComponent<Shooting>().StartAmmo += wc.weapons[3].GetComponent<Shooting>().ammoInColler * countColler;
                    Destroy(gameObject);
                    break;

                case "flamethrower":
                    wc.weapons[4].GetComponent<Shooting>().StartAmmo += wc.weapons[4].GetComponent<Shooting>().ammoInColler * countColler;
                    Destroy(gameObject);
                    break;

            }
        }
    }
}
