using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_UI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Quaternion initialRotation;
    private Vector3 initialTransform;
    public float rotationSpeed = 1000f;
    public bool onTable = false;
    public bool maxCard = false;

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
        Debug.Log("Finished dragging " + gameObject.name);
        if (onTable == true && maxCard == false)
        {
            //snap to a particular place
            maxCard = true;
        }
        else
        {
            transform.position = initialTransform;
            transform.rotation = initialRotation;
        }
    }

    void Start()
    {
        initialRotation = transform.rotation;
        initialTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table") && maxCard == false)
        {
            onTable = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Table"))
        {
            onTable = false;
            maxCard = false;
        }
    }
}
