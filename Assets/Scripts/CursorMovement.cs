using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {
    // fields
    Vector3 mousePos;
    
	// Update is called once per frame
	void Update () {
        // get mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        // set position as mouse pos
        transform.position = mousePos;
    }
}
