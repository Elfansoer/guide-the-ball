using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingCollider : MonoBehaviour {
    // Fields
    EdgeCollider2D collider;
    public List<Vector2> boundaryPoints;

    void Awake() {
        // instantiate collider
        collider = GetComponent<EdgeCollider2D>();

        // Get Camera boundaries
        float x0, x1, y0, y1;
        Camera mainCam = Camera.main;
        Vector2 pos = new Vector2(mainCam.transform.localPosition.x, mainCam.transform.localPosition.y);

        y0 = pos.y - mainCam.orthographicSize;
        y1 = pos.y + mainCam.orthographicSize;
        x0 = pos.x - mainCam.orthographicSize * mainCam.aspect;
        x1 = pos.x + mainCam.orthographicSize * mainCam.aspect;

        // set collider points
        boundaryPoints.Add(new Vector2(x0, y0));
        boundaryPoints.Add(new Vector2(x0, y1));
        boundaryPoints.Add(new Vector2(x1, y1));
        boundaryPoints.Add(new Vector2(x1, y0));
        boundaryPoints.Add(new Vector2(x0, y0));
        collider.points = boundaryPoints.ToArray();
    }
}
