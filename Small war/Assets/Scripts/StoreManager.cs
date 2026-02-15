using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    readonly List<GameObject> instantiatedObjectsListOne = new();
    readonly List<GameObject> instantiatedObjectsListTwo = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList(GameObject gameObject, int num)
    {
        if (num == 1)
        {
            instantiatedObjectsListOne.Add(gameObject);
        }else
        {
            instantiatedObjectsListTwo.Add(gameObject);
        }
        RemoveDestroyed();

        Debug.Log("p1 " + instantiatedObjectsListOne.Count);
        Debug.Log("p2 " + instantiatedObjectsListTwo.Count);
    }

    void RemoveDestroyed()
    {
        instantiatedObjectsListOne.RemoveAll(item => item == null);
        instantiatedObjectsListTwo.RemoveAll(item => item == null);
    }

    public GameObject GetAttackPosition()
    {
        RemoveDestroyed();
        foreach (GameObject compObject in instantiatedObjectsListTwo)
        {
            foreach (GameObject playerObject in instantiatedObjectsListOne)
            {
                float distance = Vector2.Distance(compObject.transform.position, playerObject.transform.position);
                if (distance <= 6f)
                {
                    return playerObject;
                }
            }
        }
        return null;
    }

}
