using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public GameObject shotGun;
    public GameObject pistol;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            shotGun.SetActive(false);
            pistol.GetComponent<Shooting>().CanShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol.SetActive(false);
            shotGun.SetActive(true);
            shotGun.GetComponent<Shooting>().CanShoot = true;
        }
    }
}
