using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Shooting
{
    // Update is called once per frame
    Quaternion angle = new Quaternion();
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
        {
            for (int i = 0; i < 30; i++)
            {
                Bullet.GetComponent<Bullet>().Dmg = 3;
                Bullet.GetComponent<Bullet>().Speed = 200;
                angle.eulerAngles = PivotPoint.rotation.eulerAngles + new Vector3(Random.Range(0, 30), Random.Range(0, 30), 0);
                Instantiate(Bullet, PivotPoint.position, angle);
            }
            Ammo--;

            //TODO: Звук выстрела и спавн эффекта выстрела
            CanShoot = false;
            StartCoroutine(WaitTillShoot(1f));
        }
        else if (Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || (Input.GetButtonDown("Fire1") && Ammo <= 0))
        {
            if (CanShoot)
                StartCoroutine(Reload(2f));
            CanShoot = false;
        }
    }
}
