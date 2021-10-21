using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyPistol : Shooting
{
    Enemy enemy;

    void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();
        StartAmmo -= ammoInColler;
        Ammo = ammoInColler;
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (enemy.nav.enabled && CanShoot && Ammo > 0 && enemy.transform.localRotation.z.Equals(enemy.player.transform))
        {
            RaycastHit hit;
            if (Physics.Linecast(LastPos, this.transform.position, out hit))
            {

            }    
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            Shoot();
            Flash();
        }
        /*else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = altDmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            AltShoot();
            Flash();
        }*/
        else if (CanShoot && Ammo <= 0)
        {
            //if (CanShoot)
            Reload();
            CanShoot = false;
        }
    }

    public void PlayShot()
    {
        Audio.clip = ShotSound;
        Audio.Play();
    }
}
