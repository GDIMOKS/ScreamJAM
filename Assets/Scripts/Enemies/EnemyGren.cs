using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGren : GrenLauncher
{
    Enemy enemy;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        enemy = transform.GetComponentInParent<Enemy>();
        StartAmmo -= ammoInColler;
        Ammo = ammoInColler;
        anim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.parent.LookAt(enemy.player.transform);
        //transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, transform.parent.eulerAngles.y);
        if (enemy.nav.enabled && CanShoot && Ammo > 0)
        {
            RaycastHit hit;
            if (Physics.Linecast(this.transform.parent.parent.position, this.transform.parent.parent.position + transform.parent.parent.TransformDirection(Vector3.forward * 20f), out hit))
            {

                if (hit.transform.CompareTag("Player"))
                {
                    //Bullet.GetComponent<GrenBullet>().enemies = false;
                    //Bullet.GetComponent<GrenBullet>().Dmg = dmg;
                    //Bullet.GetComponent<GrenBullet>().Speed = speed;
                    //Bullet.GetComponent<GrenBullet>().lifeTime = bullLifeTime;
                    //Shoot();
                    //Flash();

                    altBullet.GetComponent<GrenBulletAlt>().Dmg = altDmg;
                    altBullet.GetComponent<GrenBulletAlt>().Speed = altSpeed;
                    altBullet.GetComponent<GrenBulletAlt>().lifeTime = altBullLifeTime;
                    AltShoot();
                }

            }

            //Bullet.GetComponent<GrenBullet>().Dmg = dmg;
            //Bullet.GetComponent<GrenBullet>().Speed = speed;
            //Bullet.GetComponent<GrenBullet>().lifeTime = bullLifeTime;
            //Shoot();
        }/*
        else if (CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<GrenBulletAlt>().Dmg = altDmg;
            altBullet.GetComponent<GrenBulletAlt>().Speed = altSpeed;
            altBullet.GetComponent<GrenBulletAlt>().lifeTime = altBullLifeTime;
            AltShoot();
        }*/
        else if (CanShoot && Ammo <= 0)
        {
            //if (CanShoot)
            StartCoroutine(Reload(reloadTime));
            CanShoot = false;
        }
    }
}
