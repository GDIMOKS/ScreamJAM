using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureLife : MonoBehaviour
{
    public int healPoints;
    public bool dead = false;
    public HealthBar healthBar;
    public int maxHealth;

    void Start()
    {
        healPoints = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
            Destroy(gameObject);
        }
    }
}
