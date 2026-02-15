using UnityEngine;

public class ComputerController : Controller
{

    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
        lineRender = FindFirstObjectByType<LineRender>();
        startPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 pos = new(-3f, -1);  // pos not more than 5.5
            pos = ResetPosIntoBoundary(pos);

            GameObject gameObjectClone = CreateLineCheckForHitSpawn(pos);

        }
    }
}

