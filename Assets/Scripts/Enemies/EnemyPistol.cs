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
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (enemy.nav.enabled)
        {
            transform.parent.LookAt(enemy.player.transform);
            transform.parent.eulerAngles = new Vector3(0f, transform.parent.eulerAngles.y, 0f);
        }
        
        if (enemy.nav.enabled && CanShoot && Ammo > 0)
        {
            RaycastHit hit;
            if (Physics.Linecast(PivotPoint.transform.position, PivotPoint.transform.position + transform.TransformDirection(Vector3.forward * 20f), out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Bullet.GetComponent<Bullet>().enemies = false;
                    Bullet.GetComponent<Bullet>().Dmg = dmg;
                    Bullet.GetComponent<Bullet>().Speed = speed;
                    Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
                    Shoot();
                    Flash();
                }    
                
            }    
            
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

    
}
