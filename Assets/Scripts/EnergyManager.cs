using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance;
    public GameManager gm;
    public Card card;
    public Card_data card_Data;
    public TMP_Text energy;
    public int currentEnergy;
    public int maxEnergy;
    
    void Awake() => Instance = this;
    public bool CanAfford(int energyCost) => currentEnergy >= energyCost;
    public void SpendEnergy(int cost)
    {
        currentEnergy -= cost;
        Debug.Log("This works!");
        UpdateUI();
        Debug.Log("This works!3");
    }

    public void RefillEnergy()
    {
        currentEnergy = maxEnergy;
        UpdateUI();
    }
    void UpdateUI()
    {
        energy.text = "energy " + currentEnergy.ToString();
    }
    public void OnCardPlayed()
    {
        if (EnergyManager.Instance.CanAfford(card.cost))
        {
            Debug.Log("This works!2");
            EnergyManager.Instance.SpendEnergy(card.cost);
        }
        else
        {
            Debug.Log("Not enough energy!");
            gm.UpdateCardPositions();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
