using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable_sprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryStartDrag();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Debug.Log("test 1");
            DragObject();
        }
    }
    
    void TryStartDrag()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Debug.Log("test 2");
            isDragging = true;
            Debug.Log("test 3");
            offset = transform.position - worldPos;
            offset.z = 0;
        }
    }

    void DragObject()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        worldPos.z = transform.position.z;
        transform.position = worldPos + offset;
    }
}

