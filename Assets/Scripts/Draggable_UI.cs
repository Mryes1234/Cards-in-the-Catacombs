using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_UI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameManager gm;
    public EnergyManager em;
    public DamageManager dm;
    public GameObject table;
    public GameObject cardplaced;
    public Vector2 activeTransform;
    public int cost;
    public Card card;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Quaternion initialRotation;
    public float rotationSpeed = 1000f;
    public bool onTable = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Started dragging " + gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onTable == true)
        {
            gm.CurrentIndex = cost;
            gm.Activate();
            Destroy(cardplaced);
            card = gameObject.GetComponent<Card>();
            em.OnCardPlayed(card);
            dm.OnCardPlayed(card);
            gm.UpdateTableCardPositions();
        }
        else
        {
            gm.UpdateCardPositions();
            em.RefillEnergy();
        }
    }

    void Start()
    {
        initialRotation = table.transform.rotation;
        activeTransform = table.transform.position;
        cost = card.CurrentIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            onTable = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Table"))
        {
            onTable = false;
        }
    }
}
