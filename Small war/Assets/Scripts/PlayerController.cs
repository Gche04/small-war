using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float power = 10f;
    [SerializeField] float maxDragDistance = 5f;
    [SerializeField] float maxPower = 5.5f;
    [SerializeField] float minPower = 0;

    [SerializeField] GameObject lookAt;
    [SerializeField] GameObject rotateBody;

    LineRenderer lineRenderer;
    Rigidbody2D rb;

    Vector2 startPos;
    Vector2 offsetPos;

    bool isDragging = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            // make drag point at body 
            rb.MoveRotation(RotateWithTarget(lookAt.transform, transform));
            //make body rotate with drag
            rotateBody.transform.rotation = RotateWithTarget(transform, rotateBody.transform);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        // Calculate the offset when the mouse button is pressed down
        offsetPos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            lineRenderer.enabled = true;
            isDragging = false;

            rb.transform.position = power * transform.up;

            Vector2 endPos = transform.position;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);

            rb.transform.position = startPos;
        }
    }

    Quaternion RotateWithTarget(Transform target, Transform rotate) //make object rotation follow a target
    {
        Vector3 targetPos = target.position - rotate.position;
        Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, targetPos);
        return targetRot;
    }
}
