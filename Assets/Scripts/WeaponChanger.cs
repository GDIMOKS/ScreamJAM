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
    public GameObject flameThrower;

    void Start()
    {
        weapons = new GameObject[] {pistol, shotGun, grenLauncher, autoRifle, flameThrower};
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
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChooseWeapon(flameThrower);
        }
    }

    public void ChooseWeapon(GameObject obj)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].Equals(obj))
            {
                weapons[i].SetActive(true);
                Shooting sht;
                if (weapons[i].TryGetComponent<Shooting>(out sht))
                {
                    sht.CanShoot = true;
                }
                if (weapons[i].TryGetComponent<Animator>(out var anim))
                {
                    anim.SetTrigger("Take");
                }
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
