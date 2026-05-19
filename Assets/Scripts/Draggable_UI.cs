using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_UI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameManager gm;
    public GameObject table;
    public Vector2 activeTransform;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Quaternion initialRotation;
    private Vector3 initialTransform;
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
            transform.position = activeTransform;
            transform.rotation = initialRotation;
        }
        else
        {
            gm.UpdateCardPositions();
        }
    }

    void Start()
    {
        initialRotation = transform.rotation;
        initialTransform = transform.position;
        activeTransform = table.transform.position;
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
