using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance;
    public GameManager gm;
    public Card card;
    public TMP_Text energy;
    public int currentEnergy;
    public int maxEnergy;
    
    void Awake() => Instance = this;
    public bool CanAfford(int energyCost) => currentEnergy >= energyCost;
    public void SpendEnergy(int cost)
    {
        currentEnergy -= cost;
        UpdateUI();
    }

    public void RefillEnergy()
    {
        currentEnergy = maxEnergy;
        UpdateUI();
    }
    void UpdateUI()
    {
        energy.text = "" + currentEnergy.ToString();
    }
    public void OnCardPlayed(Card card)
    {
        if (EnergyManager.Instance.CanAfford(card.cost))
        {
            EnergyManager.Instance.SpendEnergy(card.cost);
        }
        else
        {
            Debug.Log("Not enough energy!");
            gm.UpdateCardPositions();
            RefillEnergy();
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
