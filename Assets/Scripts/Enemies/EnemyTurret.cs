using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : AutoRifle
{
    Enemy enemy;
    float damping = 0.1f;
    //public GameObject player;

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
        //var lookPos = enemy.player.transform.position - transform.position;
        //var rotation = Quaternion.LookRotation(lookPos);
        //transform.parent.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        
        transform.parent.LookAt(enemy.player.transform);
        transform.parent.eulerAngles = new Vector3(0f, transform.parent.eulerAngles.y, 0f);

        if (enemy.nav.enabled && CanShoot && Ammo > 0)
        {
            
            RaycastHit hit;
            if (Physics.Linecast(this.transform.parent.parent.position, this.transform.parent.parent.position + transform.parent.parent.TransformDirection(Vector3.forward * 20f), out hit))
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

        }/*
        else if ( && CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<AltAutorifleBullet>().Dmg = altDmg;
            altBullet.GetComponent<AltAutorifleBullet>().Speed = speed;
            altBullet.GetComponent<AltAutorifleBullet>().lifeTime = bullLifeTime;
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
