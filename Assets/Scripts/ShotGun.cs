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
            angle.eulerAngles = PivotPoint.rotation.eulerAngles + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-5.5f, 5.5f), Random.Range(-5.5f, 5.5f));
            Instantiate(Bullet, PivotPoint.position, angle);
        }
        Ammo--;

        anim.SetTrigger("Shot");
        CanShoot = false;
        //StartCoroutine(WaitTillShoot(shootTime));
    }

    public override void AltShoot()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(Bullet, PivotPoint.position + transform.TransformDirection(new Vector3(Random.Range(-0.25f, 0.25f), 0, 0)), PivotPoint.rotation);
        }
        Ammo--;

        anim.SetTrigger("Shot");
        CanShoot = false;
        //(WaitTillShoot(altShootTime));
    }
    public override void Reload()
    {
        anim.SetTrigger("Reload");
    }

    public override void ReloadEnd()
    {
        if (StartAmmo > 0)
        {
            if (StartAmmo >= ammoInColler)
            {
                StartAmmo--;
                Ammo++;
            }
            else
            {
                Ammo = StartAmmo;
                StartAmmo -= StartAmmo;
            }
        }

        CanShoot = true;
    }
    public override void Wait()
    {
        anim.SetTrigger("Wait");
    }
}
