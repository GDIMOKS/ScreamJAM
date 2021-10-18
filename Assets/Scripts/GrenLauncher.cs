using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenLauncher : Shooting
{
    //public GameObject Bullet;
    [SerializeField]
    private GameObject altBullet;
    public int altDmg;
    public int altSpeed;
    public float altBullLifeTime;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<GrenBullet>().Dmg = dmg;
            Bullet.GetComponent<GrenBullet>().Speed = speed;
            Bullet.GetComponent<GrenBullet>().lifeTime = bullLifeTime;
            Shoot();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<GrenBulletAlt>().Dmg = altDmg;
            altBullet.GetComponent<GrenBulletAlt>().Speed = altSpeed;
            altBullet.GetComponent<GrenBulletAlt>().lifeTime = altBullLifeTime;
            AltShoot();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
            StartCoroutine(Reload(reloadTime));
            CanShoot = false;
        }
    }
    public override void Shoot()
    {
        
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        Ammo--;

        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(shootTime));
    }

    public override void AltShoot()
    {
        Instantiate(altBullet, PivotPoint.position, PivotPoint.rotation);
        Ammo--;

        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(altShootTime));
    }
}
