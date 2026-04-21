using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card_data> deck = new List<Card_data>();
    public List<Card_data> player_deck = new List<Card_data>();
    public List<Card_data> ai_deck = new List<Card_data>();
    public List<Card> player_hand = new List<Card>();
    public List<GameObject> player_hand_object = new List<GameObject>();
    public List<Card_data> ai_hand = new List<Card_data>();
    public List<Card_data> discard_pile = new List<Card_data>();

    public Canvas canvas;
    public Card_data data;
    public Vector3 Player_hand_pos;
    public Vector3 ai_hand_pos;
    public Card blank;
    float currentAngle = 30f;
    float step = -15f;
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        Shuffle();
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        for (int i = 0; i < 5; i += 1)
        {
            Card top_card = Instantiate(blank, Player_hand_pos, Quaternion.Euler(0, 0, currentAngle), canvas.transform);
            currentAngle += step;
            Player_hand_pos.x += 115;
            top_card.data = player_deck[0];
            
            player_hand.Add(top_card);
            player_deck.RemoveAt(0);
            
            //ai_hand.Add(deck[0]);
            //deck.RemoveAt(0);
        }
    }

    void Shuffle()
    {
        player_deck = player_deck.OrderBy(x => Random.value).ToList();
    }

    void AI_Turn()
    {
        int random = Random.Range(0, ai_hand.Count);
    }



    
}
