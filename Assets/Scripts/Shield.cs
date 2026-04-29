using System;
using TMPro;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int maxShield = 8;
    public int currentShield;
    public TextMeshProUGUI shieldText;
    public ShieldBar shield;
    void Start()
    {
        currentShield = maxShield;
        UpdateShieldUI();
        if (shield != null) shield.SetMaxShield(maxShield);
    }

    // public void TakeDamage()
    // {
    //     currentShield -= damage;
    //     currentShield = Mathf.Clamp(currentShield, 0, maxShield);
    //     if (shield != null) shield.SetMaxShield(maxShield);
    //     if (currentShield <= 0)
    //     {
    //         Die();
    //     }
    // }

    void UpdateShieldUI()
    {
        shieldText.text = "Shield: " + currentShield + " / " + maxShield;
    }
    
    void Die()
    {
        Debug.Log("You Died");
    }

    void Update()
    {
        
    }
}
