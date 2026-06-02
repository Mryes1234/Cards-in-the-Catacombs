using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHP : MonoBehaviour
{
    public Slider Enemy_Health;
    public Card card;
    public TextMeshProUGUI AI_healthText;
    public float maxHealth = 15f;
    public float currentHealth;
    [SerializeField] private TextMeshProUGUI winCondition;
    void Start()
    {
        winCondition.enabled = false;
        RandomSlider();
        UpdateAIHealthBar();
    }
    public void TakeDamage(Card card)
    {
        currentHealth -= card.damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateAIHealthBar();
    }

    public void RandomSlider()
    {
        currentHealth = Random.Range(8, 15);
        maxHealth = currentHealth;
        Enemy_Health.value = currentHealth;
        Enemy_Health.maxValue = currentHealth;
    }
    public void Win()
    {
        if (winCondition != null)
        {
            winCondition.enabled = true;
        }
    }
    public void UpdateAIHealthBar()
    {
        if (currentHealth > 0)
        {
            AI_healthText.text = "HP: " + currentHealth + " / " + maxHealth;
            Enemy_Health.value = currentHealth;
        }
        else
        {
            AI_healthText.text = "HP: " + currentHealth + " / " + maxHealth;
            Enemy_Health.value = currentHealth;
            Win();
        }
    }
}
