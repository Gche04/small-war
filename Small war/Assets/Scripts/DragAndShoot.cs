using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    //[SerializeField] float power = 10f;
    float power = 10f;
    [SerializeField] float maxDragDistance = 5f;
    [SerializeField] float maxPower = 5.5f;
    [SerializeField] float minPower = 0;

    [SerializeField] GameObject lookAt;

    LineRenderer lineRenderer;
    Rigidbody2D rb;


    Vector2 startPos;
    Vector2 endPos;
    Vector2 forceDistance;
    Vector2 offsetPos;

    bool isDragging = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        lineRenderer.enabled = false;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 targetPos = lookAt.transform.position - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, targetPos);

            rb.MoveRotation(targetRot);
        }

    }

    void OnMouseDown()
    {
        isDragging = true;
        // Calculate the offset when the mouse button is pressed down
        offsetPos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //lineRenderer.enabled = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert mouse position to world coordinates
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Update the object's position based on the new mouse position and the calculated offset
            transform.position = currentPos + offsetPos;
            transform.position = Vector2.ClampMagnitude(transform.position, maxDragDistance);

            //get distance between startpos and position
            float distance = Vector2.Distance(startPos, transform.position);
            //clamp power min max
            power = Mathf.Clamp(distance, minPower, maxPower);
            

        }
    }

    void OnMouseUp()
    {
        // Reset the dragging flag when the mouse button is released
        if (isDragging)
        {
            isDragging = false;
            
            rb.transform.position = power * transform.up;
            
        }

    }
}

