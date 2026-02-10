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

    protected bool isDragging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawnManager = FindFirstObjectByType<SpawnManager>();
        //lineRender = FindFirstObjectByType<LineRender>();
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
}
