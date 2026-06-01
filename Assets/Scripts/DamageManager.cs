using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageManager : MonoBehaviour
{
    public Slider slider;
    public Card card;
    public GameObject AI;
    public EnemyHP ep;
    public TextMeshProUGUI healthText;
    public float maxHealth = 12f;
    public float currentHealth;
    public float damage;
    void Start()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }
    
    public void OnCardPlayed(Card card)
    {
        EnemyHP enemy = AI.GetComponent<EnemyHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(card);
            ep.UpdateAIHealthBar();
        }
    }
    void UpdateHealthBar()
    {
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
    }
    void Update()
    {
        
    }
}
