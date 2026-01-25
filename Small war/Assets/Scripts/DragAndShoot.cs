using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] float maxDragDistance = 5f;

    LineRenderer lineRenderer;
    Rigidbody2D objectRb;
    Camera mainCamera;

    Vector2 startPoint;
    Vector2 endpoint;
    Vector2 force;

    bool isDragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        objectRb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.enabled = true;
        }
    }
}
