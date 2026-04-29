using System;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 12;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public HealthBar healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
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

    void UpdateHealthUI()
    {
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
    }
    
    void Die()
    {
        Debug.Log("You Died");
    }

    void Update()
    {
        
    }
}
