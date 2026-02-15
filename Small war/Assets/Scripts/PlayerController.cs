using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    readonly float cancelShootThreshold = 0.2f;

    int instantiatedObjectsListOne = 1;

    Vector2 offsetPos;
    Vector3 defaultScale;
    Vector3 upScale;

    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
        lineRender = FindFirstObjectByType<LineRender>();
        storeManager =  FindFirstObjectByType<StoreManager>();
        storeManager.AddToList(gameObject, instantiatedObjectsListOne);
        isDragging = false;
        startPos = dragAndShoot.transform.position;
        defaultScale = dragAndShoot.transform.localScale;
        upScale = dragAndShoot.transform.localScale * 2;
    }

    void Update()
    {
        if (isDragging)
        {
            // make drag point at body 
            dragAndShoot.transform.rotation = RotateWithTarget(gameObject, dragAndShoot);
            //make body rotate with drag
            rotateBody.transform.rotation = RotateWithTarget(dragAndShoot, rotateBody);
        }
    }

    void OnMouseDown()
    {
        if (gameObject != null)
        {
            isDragging = true;
            // Calculate the offset when the mouse button is pressed down
            offsetPos = dragAndShoot.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert mouse position to world coordinates
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Update the object's position based on the new mouse position and the calculated offset
            dragAndShoot.transform.position = currentPos + offsetPos;

            //get distance between startpos and position
            float distance = Vector2.Distance(startPos, dragAndShoot.transform.position);

            if (distance <= cancelShootThreshold)
            {
                dragAndShoot.transform.localScale = upScale;
            }
            else
            {
                dragAndShoot.transform.localScale = defaultScale;
            }

            //clamp power min max
            power = Mathf.Clamp(distance, minPower, maxPower);
        }
    }

    void OnMouseUp()
    {

        if (dragAndShoot.transform.localScale != defaultScale)
        {
            isDragging = false;
            dragAndShoot.transform.position = transform.position;
            dragAndShoot.transform.localScale = defaultScale;
        }

        // Reset the dragging flag when the mouse button is released
        else if (isDragging)
        {
            GameObject gameObjectClone = Shoot();

            storeManager.AddToList(gameObjectClone, instantiatedObjectsListOne);
        }

    }
}
