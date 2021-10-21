using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRifle : Shooting
{
    
    public GameObject altBullet;

    private void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().enemies = true;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            Shoot();
            Flash();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<AltAutorifleBullet>().Dmg = altDmg;
            Bullet.GetComponent<Bullet>().enemies = true;
            altBullet.GetComponent<AltAutorifleBullet>().Speed = speed;
            altBullet.GetComponent<AltAutorifleBullet>().lifeTime = bullLifeTime;
            AltShoot();
            Flash();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
            Reload();
            CanShoot = false;
        }
    }

    public override void AltShoot()
    {
        Ammo--;
        Instantiate(altBullet, PivotPoint.position, PivotPoint.rotation);
        if (anim != null)
        {
            anim.SetTrigger("AltShot");
        }
        PlayShot();
        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        //StartCoroutine(WaitTillShoot(altShootTime));
    }
    public override void Shoot()
    {
        Ammo--;
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        if (anim != null)
        {
            anim.SetTrigger("Shot");
        }
        PlayShot();
        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(shootTime));
    }
}
