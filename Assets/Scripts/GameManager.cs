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
    public EnergyManager em;
    [SerializeField] private int maxHandSize;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private SplineContainer tableSplineContainer;
    [SerializeField] private Transform tableSpawnPoint;
    public List<Card_data> deck = new List<Card_data>();
    public List<Card_data> player_deck = new List<Card_data>();
    public List<Card_data> table_deck = new List<Card_data>();
    public List<Card_data> ai_deck = new List<Card_data>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> table_hand = new List<Card>();
    public List<Card> discard = new List<Card>();
    public List<Card> Active_player_cards = new List<Card>();
    public List<GameObject> player_hand_object = new List<GameObject>();
    public List<GameObject> Active_player_hand_object = new List<GameObject>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card_data> discard_pile = new List<Card_data>();

    public Canvas canvas;
    public Card_data data;
    public int CurrentIndex = 4927;
    public Vector3 Player_hand_pos;
    public Vector3 ai_hand_pos;
    public Card blank;
    public Card activeblank;
    public Button myButton;
    public GameObject table;
    public Vector3 offset;
    public Vector3 tableOffset;
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

    public void UpdateTableCardPositions()
    {
        if (Active_player_hand_object.Count == 0) return;
        float cardSpacing = 1f / maxHandSize;
        float firstCardPosition = 0.5f - (Active_player_hand_object.Count - 1) * cardSpacing / 2;
        Spline tableSpline = splineContainer.Spline;
        
        for (int i = 0; i < Active_player_hand_object.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 tableSplinePosition = tableSpline.EvaluatePosition(p);
            print(tableSplinePosition);
            //Vector3 splinePosition = 
            Vector3 forward = tableSpline.EvaluateTangent(p);
            Vector3 up = tableSpline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            Active_player_hand_object[i].transform.DOMove(tableSplinePosition + tableOffset, 0.25f);
            Active_player_hand_object[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
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
    public void Activate()
    {
        if(em.CanAfford(em.energyCost) == true)
        {
            Card activeCard = Instantiate(activeblank, table.transform.position, table.transform.rotation, canvas.transform);
            activeCard.data = player_hand[CurrentIndex].data;
            Active_player_cards.Add(activeCard);
            Active_player_hand_object.Add(activeCard.gameObject);
            player_hand.RemoveAt(CurrentIndex);
            player_hand_object.RemoveAt(CurrentIndex);
            activeCard.CurrentIndex = Active_player_cards.Count -1;
        }
        else
        {
            UpdateCardPositions();
            UpdateTableCardPositions();
        }
        
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
