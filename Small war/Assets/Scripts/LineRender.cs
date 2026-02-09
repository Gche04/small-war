using System.Linq;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] LayerMask collisionLayer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    public void CreateLine(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    public void CheckForHit(Vector2 startPos, Vector2 endPos, GameObject gameObject)
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(startPos, endPos, collisionLayer);
        // Create a new array, skipping the first element
        hits = hits.Skip(1).ToArray();

        if (hits.Length > 0)
        {
            // The line has hit an object
            foreach (RaycastHit2D hit in hits)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
