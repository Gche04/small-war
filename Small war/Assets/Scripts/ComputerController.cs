using UnityEngine;

public class ComputerController : Controller
{
    float simulationDuration;
    float startTime;

    Vector2 worldEndPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
        lineRender = FindFirstObjectByType<LineRender>();
        startPos = transform.position;
        //isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 pos = new(-2, -1);
            ResetPosIntoBoundary(pos);
            //dragAndShoot.transform.position = pos;

            //lineRender.CreateLine(startPos, pos);
            //lineRender.CheckForHit(startPos, pos, gameObject);
            //spawnManager.SpawnAtPosition(gameObject, pos);

            //dragAndShoot.transform.position = transform.position;

            
            LineHitSpawn(pos);
            //isDragging = true;
            //power = 4.5f;

             //float distance = Vector2.Distance(startPos, pos);

             //power = Mathf.Clamp(distance, minPower, maxPower);
            //SimulateObjectDrag(pos);
        }



        //if (isDragging)
        //{
            /*isDragging = false;

            dragAndShoot.transform.position = dragAndShoot.transform.position + dragAndShoot.transform.up * power;

            //reset position into boundary
            Vector2 pos = dragAndShoot.transform.position;
            pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
            pos.y = Mathf.Clamp(pos.y, -boundary, boundary);

            dragAndShoot.transform.position = pos;

            endPos = dragAndShoot.transform.position;
            lineRender.CreateLine(startPos, endPos);
            lineRender.CheckForHit(startPos, endPos, gameObject);

            dragAndShoot.transform.position = transform.position;

            spawnManager.SpawnAtPosition(gameObject, endPos);*/
            //float t = (Time.time - startTime) / simulationDuration;
            //dragAndShoot.transform.position = Vector2.Lerp(startPos, worldEndPos, t);

            //if (t >= 1.0f)
            //{
            //Shoot();
            // Trigger any logic that would happen OnMouseUp
            //Debug.Log("Simulated Mouse Up");
            //}
        //}
    }

    public void SimulateObjectDrag(Vector3 worldEndPoint)
    {
        worldEndPos = worldEndPoint;
        dragAndShoot.transform.position = worldEndPoint;
        //simulationDuration = duration;
        //startTime = Time.time;

        float distance = Vector2.Distance(startPos, worldEndPoint);

        //clamp power min max
        power = Mathf.Clamp(distance, minPower, maxPower);

        //isDragging = true;
        // Trigger any logic that would happen OnMouseDown
        //Debug.Log("Simulated Mouse Down");
    }
    /*
    public void SimulateObjectDrag(Vector2 worldEndPoint, float duration)
    {
        worldEndPos = worldEndPoint;
        //dragAndShoot.transform.position = worldEndPoint;
        simulationDuration = duration;
        startTime = Time.time;

        float distance = Vector2.Distance(startPos, worldEndPoint);

        //clamp power min max
        power = Mathf.Clamp(distance, minPower, maxPower);

        isDragging = true;
        // Trigger any logic that would happen OnMouseDown
        Debug.Log("Simulated Mouse Down");
    }
    */
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