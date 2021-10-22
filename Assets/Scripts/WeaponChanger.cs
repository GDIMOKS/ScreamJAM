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
    public string keyValue;
    public int keyValueInt;

    void Start()
    {
        keyValueInt = 1;
        weapons = new GameObject[] {pistol, shotGun, grenLauncher, autoRifle, flameThrower};
    }

    void Update()
    {
        ChooseWeaponScroll(out keyValue);

        switch (keyValue)
        {
            case "1":
                ChooseWeapon(pistol);
                break;

            case "2":
                ChooseWeapon(shotGun);
                break;

            case "3":
                ChooseWeapon(grenLauncher);
                break;

            case "4":
                ChooseWeapon(autoRifle);
                break;

            case "5":
                ChooseWeapon(flameThrower);
                break;
        }
        /*
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
        }*/
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

    public string ChooseWeaponScroll(out string keyValue)
    {
        keyValue = Input.inputString;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            keyValueInt--;
            if (keyValueInt < 1)
            {
                keyValueInt = 5;
            }
            keyValue = keyValueInt.ToString();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            keyValueInt++;
            if (keyValueInt > 5)
            {
                keyValueInt = 1;
            }
            keyValue = keyValueInt.ToString();
        }

        return keyValue;
    }
}
