using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
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
            NavMeshAgent nma;
            if (anim != null && TryGetComponent<NavMeshAgent>(out nma))
            {
                anim.SetTrigger("Die");
                nma.enabled = false;
                this.enabled = false;
            }
            else
            {
                TryGetComponent<Animator>(out anim);
                if (anim != null && TryGetComponent<NavMeshAgent>(out nma))
                {
                    anim.SetTrigger("Die");
                    nma.enabled = false;
                    this.enabled = false;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
