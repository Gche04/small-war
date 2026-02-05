using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int player;

    [SerializeField] GameObject spawnManager;
    [SerializeField] GameObject dragAndShoot;
    [SerializeField] GameObject lookAt;
    [SerializeField] GameObject rotateBody;

    float power = 10f;
    [SerializeField] float maxDragDistance = 5f;
    [SerializeField] float maxPower = 5.5f;
    [SerializeField] float minPower = 0;

    LineRenderer lineRenderer;
    Rigidbody2D dragAndShootRb;

    Vector2 startPos;
    Vector2 offsetPos;

    bool isDragging = false;

    void Start()
    {
        lineRenderer = dragAndShoot.GetComponent<LineRenderer>();
        dragAndShootRb = dragAndShoot.GetComponent<Rigidbody2D>();
        startPos = dragAndShoot.transform.position;
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
            dragAndShootRb.MoveRotation(RotateWithTarget(lookAt, dragAndShoot));
            //make body rotate with drag
            rotateBody.transform.rotation = RotateWithTarget(dragAndShoot, rotateBody);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        // Calculate the offset when the mouse button is pressed down
        offsetPos = dragAndShoot.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert mouse position to world coordinates
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Update the object's position based on the new mouse position and the calculated offset
            dragAndShoot.transform.position = currentPos + offsetPos;
            dragAndShoot.transform.position = Vector2.ClampMagnitude(dragAndShoot.transform.position, maxDragDistance);

            //get distance between startpos and position
            float distance = Vector2.Distance(startPos, dragAndShoot.transform.position);
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

            dragAndShootRb.transform.position = power * dragAndShoot.transform.up;

            Vector2 endPos = dragAndShoot.transform.position;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);

            dragAndShootRb.transform.position = startPos;
        }
    }

    Quaternion RotateWithTarget(GameObject target, GameObject rotate) //make object rotation follow a target
    {
        Vector3 targetPos = target.transform.position - rotate.transform.position;
        Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, targetPos);
        return targetRot;
    }
}
