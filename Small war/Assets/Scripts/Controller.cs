using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] protected GameObject dragAndShoot;
    [SerializeField] protected GameObject lookAt;
    [SerializeField] protected GameObject rotateBody;

    protected SpawnManager spawnManager;
    protected LineRender lineRender;

    protected float power = 10f;
    protected float maxPower = 5.5f;
    protected float minPower = 0;
    protected float boundary = 5f;

    protected Vector3 startPos;
    protected Vector2 endPos;

    protected bool isDragging;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected Quaternion RotateWithTarget(GameObject target, GameObject rotate) //make object rotation follow a target
    {
        Vector3 targetPos = target.transform.position - rotate.transform.position;
        Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, targetPos);
        return targetRot;
    }

    protected void Shoot()
    {
        isDragging = false;

        dragAndShoot.transform.position = transform.position + dragAndShoot.transform.up * power;

        //reset position into boundary
        //Vector2 pos = dragAndShoot.transform.position;
        //pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
        //pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        dragAndShoot.transform.position = ResetPosIntoBoundary(dragAndShoot.transform.position);

        endPos = dragAndShoot.transform.position;

        dragAndShoot.transform.position = startPos;

        LineHitSpawn(endPos);
        //lineRender.CreateLine(startPos, endPos);
        //lineRender.CheckForHit(startPos, endPos, gameObject);
        //spawnManager.SpawnAtPosition(gameObject, endPos);
    }

    protected void LineHitSpawn(Vector3 endPosition)
    {
        lineRender.CreateLine(startPos, endPosition);
        lineRender.CheckForHit(startPos, endPosition, gameObject);
        spawnManager.SpawnAtPosition(gameObject, endPosition);
    }

    protected Vector3 ResetPosIntoBoundary(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
        pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        return pos;
    }
}
