using System.Collections.Generic;
using UnityEngine;

public class ComputerController : Controller
{
    int instantiatedObjectsListTwo = 2;

    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
        lineRender = FindFirstObjectByType<LineRender>();
        storeManager =  FindFirstObjectByType<StoreManager>();
        storeManager.AddToList(gameObject, instantiatedObjectsListTwo);
        startPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new(-3f, -1);  // pos not more than 6
            pos = ResetPosIntoBoundary(pos);

            GameObject gameObjectClone = CreateLineCheckForHitSpawn(pos);
            
            storeManager.AddToList(gameObjectClone, instantiatedObjectsListTwo);

        }
    }
}

