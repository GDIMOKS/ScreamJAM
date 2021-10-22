using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    Enemy enemy;
    public Collider col;
    public int dmg;
    void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();

        //anim = GetComponent<Animator>();
        //Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (enemy.nav.enabled)
        {
            col.enabled = true;
            //enemy.GetComponentInChildren<Melee>().Dmg = dmg;
        }
    }

    
}
