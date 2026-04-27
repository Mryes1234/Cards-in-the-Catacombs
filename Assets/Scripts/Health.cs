using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        if (healthbar != null) healthbar.SetMaxHealth(maxHealth);
    }

    // public void TakeDamage()
    // {
    //     currentHealth -= damage;
    //     currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    //     if (healthbar != null) healthbar.SetMaxHealth(maxHealth);
    //     if (currentHealth <= 0)
    //     {
    //         Die();
    //     }
    // }

    void Die()
    {
        Debug.Log("You Died");
    }

    void Update()
    {
        
    }
}
