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
    public List<Card> discard = new List<Card>();
    public List<GameObject> player_hand_object = new List<GameObject>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card_data> discard_pile = new List<Card_data>();

    public Canvas canvas;
    public Card_data data;
    public Vector3 Player_hand_pos;
    public Vector3 ai_hand_pos;
    public Card blank;
    public float spacing = 75f;
    public float amplitude = 40f;
    public float frequency = 2.105f;
    public float aifrequency = -2.105f;
    float currentAngle = 30f;
    float aicurrentAngle = 150f;
    float step = -15f;
    float aistep = 15f;
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
        AI_Turn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        for (int i = 0; i < 5; i += 1)
        {
            float x = i * spacing;
            float y = Mathf.Sin(x * frequency) * amplitude;
            Vector3 wave_shape = new Vector3(x, y, 0);
            Card top_card = Instantiate(blank, Player_hand_pos + wave_shape, Quaternion.Euler(0, 0, currentAngle), canvas.transform);
            currentAngle += step;
            top_card.data = player_deck[0];
            player_hand.Add(top_card);
            player_hand_object.Add(top_card.gameObject);
            player_deck.RemoveAt(0);
        }
    }

    void Shuffle()
    {
        player_deck = player_deck.OrderBy(x => Random.value).ToList();
        ai_deck = ai_deck.OrderBy(x => Random.value).ToList();
    }

    void AI_Turn()
    {
        for (int i = 0; i < 5; i += 1)
        {
            float x = i * spacing;
            float y = Mathf.Sin(x * aifrequency) * amplitude;
            Vector3 wave_shape = new Vector3(x, y, 0);
            Card ai_top_card = Instantiate(blank, ai_hand_pos + wave_shape, Quaternion.Euler(0, 0, aicurrentAngle), canvas.transform);
            aicurrentAngle += aistep;
            int random = Random.Range(0, ai_hand.Count);
            ai_top_card.data = ai_deck[0];
            ai_hand.Add(ai_top_card);
            ai_deck.RemoveAt(0);
        }
    }
    
    void Discard()
    {
        //discard.Add(top_card);
        //player_hand.RemoveAt(0);
    }
    //Local space for relative up when selecting cards
    
}
