using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Splines;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] private int maxHandSize;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnPoint;
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
    public int CurrentIndex = 4927;
    public Vector3 Player_hand_pos;
    public Vector3 ai_hand_pos;
    public Card blank;
    public Button myButton;
    public Vector3 offset;
    public bool drawable = true;
    public bool onTable = false;
    public bool maxCard = false;
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
        myButton.onClick.AddListener(OnButtonClicked);
        canvas = FindObjectOfType<Canvas>();
        Shuffle();
        AIUpdateCardPositions();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCardPositions()
    {
        Debug.Log("test1");
        if (player_hand_object.Count == 0) return;
        float cardSpacing = 1f / maxHandSize;
        float firstCardPosition = 0.5f - (player_hand_object.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;
        
        for (int i = 0; i < player_hand_object.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            print(splinePosition);
            //Vector3 splinePosition = 
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            player_hand_object[i].transform.DOMove(splinePosition + offset, 0.25f);
            player_hand_object[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }

    public void Draw()
    {
        if (player_hand_object.Count >= maxHandSize) return;
        Card top_card = Instantiate(blank, spawnPoint.position, spawnPoint.rotation, canvas.transform);
        top_card.data = player_deck[0];
        player_hand.Add(top_card);
        player_hand_object.Add(top_card.gameObject);
        top_card.CurrentIndex = player_hand.Count -1;
        UpdateCardPositions();
        player_deck.RemoveAt(0);
    }
    void OnButtonClicked()
    {
        Debug.Log("Button was clicked!");
        if (drawable == true)
        {
            Draw();
        }
    }
    void Shuffle()
    {
        player_deck = player_deck.OrderBy(x => Random.value).ToList();
        ai_deck = ai_deck.OrderBy(x => Random.value).ToList();
    }

    void AI_Turn()
    {
        
    }

    private void AIUpdateCardPositions()
    {
        // if (ai_hand.Count == 0) return;
        // float cardSpacing = 1f / maxHandSize;
        // float firstCardPosition = 0.5f - (ai_hand.Count - 1) * cardSpacing / 2;
        // Spline spline = splineContainer.Spline;
        // for (int i = 0; i < ai_hand.Count; i++)
        // {
        //     float p = firstCardPosition + i * cardSpacing;
        //     Vector3 splinePosition = spline.EvaluatePosition(p);
        //     Vector3 forward = spline.EvaluateTangent(p);
        //     Vector3 up = spline.EvaluateUpVector(p);
        //     Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
        //     ai_hand[i].transform.DOMove(splinePosition, 0.25f);
        //     ai_hand[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        // }
    }
    
    void Discard()
    {
        //discard.Add(top_card);
        //player_hand.RemoveAt(0);
    }
    //Local space for relative up when selecting cards
    
}
