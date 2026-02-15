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
            GameObject attack = storeManager.GetAttackPosition();
            Vector3 pos;

            if (attack != null)
            {
                pos = attack.transform.position;
            }else
            {
                pos = new(-1f, 3);
            }
            //new(-1f, 3);  // pos not more than 6
            pos = ResetPosIntoBoundary(pos);

            GameObject gameObjectClone = CreateLineCheckForHitNdClone(pos);
            
            storeManager.AddToList(gameObjectClone, instantiatedObjectsListTwo);

        }
    }
}

