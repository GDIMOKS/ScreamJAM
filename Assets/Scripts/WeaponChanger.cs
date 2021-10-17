using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject shotGun;
    public GameObject pistol;
    public GameObject grenLauncher;
    public GameObject autoRifle;

    void Start()
    {
        weapons = new GameObject[] {shotGun, pistol, grenLauncher, autoRifle};
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseWeapon(pistol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseWeapon(shotGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseWeapon(grenLauncher);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChooseWeapon(autoRifle);
        }
    }

    public void ChooseWeapon(GameObject obj)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].Equals(obj))
            {
                weapons[i].SetActive(true);
                weapons[i].GetComponent<Shooting>().CanShoot = true;
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
