using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenLauncher : Shooting
{
    //public GameObject Bullet;
    
    public GameObject altBullet;
    //public int altDmg;
    public int altSpeed;
    public float altBullLifeTime;

    private void Update()
    {
        FindObjectOfType<UIAmmo>().PrintAmmo(Ammo, StartAmmo);
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<GrenBullet>().Dmg = dmg;
            Bullet.GetComponent<GrenBullet>().Speed = speed;
            Bullet.GetComponent<GrenBullet>().lifeTime = bullLifeTime;
            Shoot();
            Flash();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<GrenBulletAlt>().Dmg = altDmg;
            altBullet.GetComponent<GrenBulletAlt>().Speed = altSpeed;
            altBullet.GetComponent<GrenBulletAlt>().lifeTime = altBullLifeTime;
            AltShoot();
            Flash();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot && Ammo < ammoInColler)
        {
            //if (CanShoot)
            //StartCoroutine(Reload(reloadTime));
            anim.SetTrigger("Reload");
            CanShoot = false;
        }
    }
    public override void Shoot()
    {
        
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        Ammo--;

        //TODO: Звук выстрела и спавн эффекта выстрела
        PlayShot();
        CanShoot = false;
        if (anim != null)
        {
            anim.SetTrigger("Shot");
        }
        else
        {
            StartCoroutine(WaitTillShoot(shootTime));
        }
    }

    public override void AltShoot()
    {
        Instantiate(altBullet, PivotPoint.position, PivotPoint.rotation);
        Ammo--;

        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        if (anim != null)
        {
            anim.SetTrigger("AltShot");
        }
        else
        {
            StartCoroutine(WaitTillShoot(altShootTime));
        }
    }
}
