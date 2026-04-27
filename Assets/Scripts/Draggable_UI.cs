using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_UI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Quaternion initialRotation;
    private Vector3 initialTransform;
    private bool onTable = false;

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
        transform.rotation = Quaternion.identity;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Finished dragging " + gameObject.name);
        if (onTable)
        {
            
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
