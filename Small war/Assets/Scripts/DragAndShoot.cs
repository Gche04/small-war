using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] float maxDragDistance = 5f;

    [SerializeField] GameObject lookAt;

    LineRenderer lineRenderer;
    Rigidbody2D rb;
    Camera mainCamera;

    Vector2 startPoint;
    Vector2 endpoint;
    Vector2 force;
    Vector2 offset;

    bool isDragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.enabled = true;
        }

        if (Input.GetMouseButtonDown(0) && isDragging)
        {
            Vector2 currentPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            
            // calculate force vector and clamp distance
            force = startPoint - currentPoint;
            force = Vector2.ClampMagnitude(force, maxDragDistance);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            lineRenderer.enabled = false;
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }*/
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
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //lineRenderer.enabled = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert mouse position to world coordinates
            Vector2 newMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Update the object's position based on the new mouse position and the calculated offset
            transform.position = newMousePosition + offset;



            //aimRotation.transform.LookAt(transform.position);
            //StretchAndPoint();
        }
    }

    void OnMouseUp()
    {
        // Reset the dragging flag when the mouse button is released
        if (isDragging)
        {
            isDragging = false;
            //lineRenderer.enabled = false;
            rb.AddForce(transform.up * power, ForceMode2D.Impulse);
        }

    }




    /*

    GameObject aimRotation;
    GameObject stretchAnchor;

    public GameObject gameManager;
    GameManger gameMangerScript;

    Rigidbody ballRb;

    public Vector3 holdPos;
    Vector3 offset; // Stores the offset between mouse position and object's center
    Vector3 holdStretch; 

    public bool isDragging = false; // Flag to track if the object is currently being dragged
    bool canShoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMangerScript = gameManager.GetComponent<GameManger>();
        ballRb = GetComponent<Rigidbody>();
        holdPos = transform.position;
        ballRb.useGravity = false;
        aimRotation = GameObject.Find("Aim Rotation");
        stretchAnchor = GameObject.Find("Stretch Anchor");
        holdStretch = stretchAnchor.transform.localScale;
        canShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseDown()
    {
        // Calculate the offset when the mouse button is pressed down
        if (canShoot)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(transform.position).z
            )
        );
            isDragging = true;
        }

    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert mouse position to world coordinates, maintaining the object's Z-depth
            Vector3 newMousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    Camera.main.WorldToScreenPoint(transform.position).z
                )
            );
            // Update the object's position based on the new mouse position and the calculated offset
            transform.position = newMousePosition + offset;
            //make x axis stay at 0
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            if (transform.position.z < 18)
            {
                transform.position = new Vector3(0f, transform.position.y, 18);
            }
            

            aimRotation.transform.LookAt(transform.position);
            StretchAndPoint();
        }
    }

    void OnMouseUp()
    {
        // Reset the dragging flag when the mouse button is released
        isDragging = false;

        float zPull = transform.position.z;
        float yPull = transform.position.y;

        float force = (zPull + yPull) * 2;

        Vector3 direction = -aimRotation.transform.forward;

        ballRb.AddForce(force * direction, ForceMode.Impulse);
        StretchRecover();
        canShoot = false;
        ballRb.useGravity = true;
        gameMangerScript.add = true;

    }

    void StretchAndPoint()
    {
        //Calculate the direction and distance of z axis
        float stretchDirZ = transform.position.z - stretchAnchor.transform.position.z;
        stretchAnchor.transform.localScale = new Vector3(
            stretchAnchor.transform.localScale.x,
            stretchAnchor.transform.localScale.y,
            stretchDirZ + 0.5f
            ); // Adjust X and Y for desired thickness

    }

    void StretchRecover()
    {
        stretchAnchor.transform.localScale = holdStretch;
    }

    */
}

