using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;

    public string card_name;
    public string description;
    public int cost;
    public int damage;
    public int heal;
    public int block;
    public Sprite sprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healText;
    public TextMeshProUGUI blockText;
    public Image spriteImage;
        

    // Start is called before the first frame update
    void Start()
    {
        card_name = data.card_name;
        description = data.description;
        cost = data.cost;
        damage = data.damage;
        block = data.block;
        heal = data.heal;
        sprite = data.sprite;
        nameText.text = card_name;
        descriptionText.text = description;
        costText.text = cost.ToString();
        damageText.text = damage.ToString();
        healText.text = heal.ToString();
        blockText.text = block.ToString();
        spriteImage.sprite = sprite;
        if (damage != 0)
        {
            damageText.text = damageText.text + " damage";
        }
        else
        {
            damageText.text = "";
        }
        if (heal != 0)
        {
            healText.text = healText.text + " health";
        }
        else
        {
            healText.text = "";
        }
        if (block != 0)
        {
            blockText.text = blockText.text + " block";
        }
        else
        {
            blockText.text = "";
        }
        costText.text = costText.text + " energy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
