using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRifle : Shooting
{
    [SerializeField]
    private GameObject altBullet;

    private void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            Shoot();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<AltAutorifleBullet>().Dmg = altDmg;
            altBullet.GetComponent<AltAutorifleBullet>().Speed = speed;
            altBullet.GetComponent<AltAutorifleBullet>().lifeTime = bullLifeTime;
            AltShoot();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
            StartCoroutine(Reload(reloadTime));
            CanShoot = false;
        }
    }

    public override void AltShoot()
    {
        Ammo--;
        Instantiate(altBullet, PivotPoint.position, PivotPoint.rotation);


        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(altShootTime));
    }
}
