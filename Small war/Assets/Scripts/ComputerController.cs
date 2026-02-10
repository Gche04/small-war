using UnityEngine;

public class ComputerController : Controller
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = dragAndShoot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SimulateObjectDrag(Vector2 worldStartPoint, Vector2 worldEndPoint, float duration)
    {
        //startPos = worldStartPoint;
        //endPos = worldEndPoint;
        //simulationDuration = duration;
        //startTime = Time.time;
        //isDraggingSimulation = true;


        float distance = Vector2.Distance(startPos, dragAndShoot.transform.position);

        //clamp power min max
        power = Mathf.Clamp(distance, minPower, maxPower);
        // Trigger any logic that would happen OnMouseDown
        Debug.Log("Simulated Mouse Down");
    }
}

/*
private bool isDraggingSimulation = false;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float simulationDuration;
    private float startTime;

    public void SimulateObjectDrag(Vector3 worldStartPoint, Vector3 worldEndPoint, float duration)
    {
        startPoint = worldStartPoint;
        endPoint = worldEndPoint;
        simulationDuration = duration;
        startTime = Time.time;
        isDraggingSimulation = true;
        
        // Trigger any logic that would happen OnMouseDown
        Debug.Log("Simulated Mouse Down");
    }

    void Update()
    {
        if (isDraggingSimulation)
        {
            float t = (Time.time - startTime) / simulationDuration;
            transform.position = Vector3.Lerp(startPoint, endPoint, t);

            if (t >= 1.0f)
            {
                isDraggingSimulation = false;
                // Trigger any logic that would happen OnMouseUp
                Debug.Log("Simulated Mouse Up");
            }
        }
    }

*/