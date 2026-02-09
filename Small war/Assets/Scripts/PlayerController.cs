using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int player;

    SpawnManager spawnManager;
    LineRender lineRender;

    [SerializeField] GameObject dragAndShoot;
    [SerializeField] GameObject lookAt;
    [SerializeField] GameObject rotateBody;

    float power = 10f;
    [SerializeField] float maxDragDistance = 5f;
    [SerializeField] float maxPower = 5.5f;
    [SerializeField] float minPower = 0;
    [SerializeField] float boundary = 10f;

    Vector2 startPos;
    Vector2 offsetPos;

    bool isDragging = false;

    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
        lineRender = FindFirstObjectByType<LineRender>();
        startPos = dragAndShoot.transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            // make drag point at body 
            dragAndShoot.transform.rotation = RotateWithTarget(gameObject, dragAndShoot);
            //make body rotate with drag
            rotateBody.transform.rotation = RotateWithTarget(dragAndShoot, rotateBody);
        }
    }

    void FixedUpdate()
    {
        
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
            isDragging = false;

            dragAndShoot.transform.position = transform.position + dragAndShoot.transform.up * power;

            //reset position into boundary
            Vector2 pos = dragAndShoot.transform.position;
            pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
            pos.y = Mathf.Clamp(pos.y, -boundary, boundary);

            dragAndShoot.transform.position = pos;

            Vector2 endPos = dragAndShoot.transform.position;
            lineRender.CreateLine(startPos, endPos);

            dragAndShoot.transform.position = transform.position;

            spawnManager.SpawnAtPosition(gameObject, endPos);
            
        }
    }

    Quaternion RotateWithTarget(GameObject target, GameObject rotate) //make object rotation follow a target
    {
        Vector3 targetPos = target.transform.position - rotate.transform.position;
        Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, targetPos);
        return targetRot;
    }
}
