using TMPro;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public AI_HealthBar health;
    void Start()
    {
        maxHealth = Random.Range(8,15);
        currentHealth = maxHealth;
        UpdateHealthUI();
        if (health != null) health.SetMaxHealth(maxHealth);
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
