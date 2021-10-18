using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Shooting
{
    Quaternion angle = new Quaternion();
    public override void Shoot()
    {
        for (int i = 0; i < 30; i++)
        {
            angle.eulerAngles = PivotPoint.rotation.eulerAngles + new Vector3(Random.Range(0, 30), Random.Range(0, 30), 0);
            Instantiate(Bullet, PivotPoint.position, angle);
        }
        Ammo--;

        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(shootTime));
    }

    public override void AltShoot()
    {
        for (int i = 0; i < 30; i++)
        {
            //angle.eulerAngles = PivotPoint.rotation.eulerAngles + new Vector3(Random.Range(0, 30), Random.Range(0, 30), 0);
            Instantiate(Bullet, PivotPoint.position + transform.TransformDirection(new Vector3(Random.Range(-0.25f, 0.25f), 0, 0)), PivotPoint.rotation);
        }
        Ammo--;

        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(altShootTime));
    }
}
