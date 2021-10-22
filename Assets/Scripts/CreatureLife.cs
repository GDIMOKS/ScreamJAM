using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CreatureLife : MonoBehaviour
{
    public int healPoints;
    public bool dead = false;
    public HealthBar healthBar;
    public int maxHealth;
    private Animator anim;
    public GameObject crl;

    void Start()
    {
        healPoints = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponentInChildren<Animator>();
    }

    public void EditHP(int value)
    {
        healPoints += value;
        healthBar.SetHealth(healPoints);
        if (healPoints <= 0)
        {
            healPoints = 0;
            dead = true;
            Death();
        }
        if (healPoints > maxHealth)
        {
            healPoints = maxHealth;
        }
    }
    
    public void Death()
    {
        if (!gameObject.CompareTag("Player"))
        {
            //GameObject parent;
            if (gameObject.CompareTag("FlyingShit"))
            {
                //parent = gameObject.transform.parent.gameObject;
                Destroy(gameObject.transform.parent.gameObject);
            }
            if (crl != null)
            {
                Destroy(crl);
            }
            if (anim != null)
            {
                anim.SetTrigger("Die");
                GetComponent<NavMeshAgent>().enabled = false;
                this.enabled = false;
            }
            else
            {
                TryGetComponent<Animator>(out anim);
                if (anim != null)
                {
                    anim.SetTrigger("Die");
                    GetComponent<NavMeshAgent>().enabled = false;
                    this.enabled = false;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
