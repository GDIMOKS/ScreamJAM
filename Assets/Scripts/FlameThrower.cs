using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Shooting
{
    public GameObject[] flame;
    public ParticleSystem[] ps;
    private void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot && Ammo > 0)
        {
            flame[0].GetComponent<FlameThrowerDmg>().Dmg = dmg;
            flame[0].GetComponent<MeshCollider>().enabled = true;
            ps[0].Play(true);
            Shoot();
            anim.SetBool("Shot", true);
        }
        else if (Input.GetButton("Fire2") && CanShoot && Ammo > 0)
        {
            flame[1].GetComponent<FlameThrowerDmg>().Dmg = dmg;
            flame[1].GetComponent<MeshCollider>().enabled = true;
            ps[1].Play(true);

            flame[2].GetComponent<FlameThrowerDmg>().Dmg = dmg;
            flame[2].GetComponent<MeshCollider>().enabled = true;
            ps[2].Play(true);
            AltShoot();
            anim.SetBool("Shot", true);
        }
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
        else if ((Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot && StartAmmo > 0)
        {
            //if (CanShoot)
            Reload();
            CanShoot = false;
            anim.SetBool("Shot", false);
            anim.SetTrigger("Reload");
        }
        else
        {
            anim.SetBool("Shot", false);
        }

        if (Input.GetButtonUp("Fire1") || !CanShoot)
        {
            flame[0].GetComponent<MeshCollider>().enabled = false;
            ps[0].Stop(true);
        }

        if (Input.GetButtonUp("Fire2") || !CanShoot)
        {
            flame[1].GetComponent<MeshCollider>().enabled = false;
            ps[1].Stop(true);

            flame[2].GetComponent<MeshCollider>().enabled = false;
            ps[2].Stop(true);
        }

    }

    public override void Shoot()
    {
        Ammo--;
    }

    public override void AltShoot()
    {
        Ammo--;
        Ammo--;
    }
}
