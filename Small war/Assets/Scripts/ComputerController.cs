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
            List<GameObject> attackMove = storeManager.GetAttackPosition();

            Vector3 pos;

            if (attackMove != null)
            {
                GameObject compGameObject = attackMove[0];
                GameObject playerGameObject = attackMove[1];

                startPos = compGameObject.transform.position;

                compGameObject.transform.rotation = RotateWithTarget(playerGameObject, compGameObject);
                pos = playerGameObject.transform.position + compGameObject.transform.up * 2;
            }else
            {
                pos = new(-1f, 3);
            }
            
            //pos = ResetPosIntoBoundary(pos);

            GameObject gameObjectClone = CreateLineCheckForHitNdClone(pos);
            
            storeManager.AddToList(gameObjectClone, instantiatedObjectsListTwo);

        }
    }
}

