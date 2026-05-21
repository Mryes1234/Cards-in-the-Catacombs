using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance;
    public GameManager gm;
    public int currentEnergy;
    public int maxEnergy;
    
    void Awake() => Instance = this;
    public bool CanAfford(int energyCost) => currentEnergy >= energyCost;
    public void SpendEnergy(int amount)
    {
        currentEnergy -= amount;
        UpdateUI();
    }

    public void RefillEnergy()
    {
        currentEnergy = maxEnergy;
        UpdateUI();
    }
    void UpdateUI()
    {
        
    }
    public void OnCardPlayed(Card_data card)
    {
        if (EnergyManager.Instance.CanAfford(card.cost))
        {
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
