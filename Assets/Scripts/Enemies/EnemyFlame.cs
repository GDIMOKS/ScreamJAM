using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlame : FlameThrower
{
    Enemy enemy;

    void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();
        
    }
    private void Update()
    {
        

        if (enemy.nav.enabled && CanShoot && Ammo > 0)
        {
            for (int i = 0; i < flame.Length; i++)
            {
                flame[i].GetComponent<MeshCollider>().enabled = true;
                flame[i].GetComponent<FlameThrowerDmg>().Dmg = dmg;
                ps[i].Play(true);
                Shoot();
                //AltShoot();
            }
        }
        /*
        else if (Input.GetButton("Fire2") && CanShoot && Ammo > 0)
        {
            flame[1].GetComponent<FlameThrowerDmg>().Dmg = dmg;
            flame[1].GetComponent<MeshCollider>().enabled = true;
            ps[1].Play(true);

            flame[2].GetComponent<FlameThrowerDmg>().Dmg = dmg;
            flame[2].GetComponent<MeshCollider>().enabled = true;
            ps[2].Play(true);
            AltShoot();
        }*/
        /*
        else if (Input.GetButton("Fire1") &&  Input.GetButton("Fire2") && CanShoot && Ammo > 0)
        {
            for (int i = 0; i < flame.Length; i++)
            {
                flame[i].GetComponent<FlameThrowerDmg>().Dmg = dmg;
                flame[i].GetComponent<MeshCollider>().enabled = true;
                ps[i].Play(true);
            }
            Shoot();
            AltShoot();
        }*/
        else if (CanShoot && Ammo <= 0)
        {
            //if (CanShoot)
            Reload();
            CanShoot = false;
        }

        if (!CanShoot)
        {
            for (int i = 0; i < flame.Length; i++)
            {
                flame[i].GetComponent<MeshCollider>().enabled = false;
                ps[i].Stop(true);
            }
        }
        /*
        if (Input.GetButtonUp("Fire2") || !CanShoot)
        {
            flame[1].GetComponent<MeshCollider>().enabled = false;
            ps[1].Stop(true);

            flame[2].GetComponent<MeshCollider>().enabled = false;
            ps[2].Stop(true);
        }*/

    }
}
