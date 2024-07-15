using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLogic : MonoBehaviour {
    // configs
    public GameObject player;
    public GameObject cursor;

    // fields
    LineRenderer line;
    Vector3[] endPoints;

	// Use this for initialization
	void Awake() {
        line = GetComponent<LineRenderer>();
        endPoints = new Vector3[2];
        line.enabled = false;
	}
	
	// Update line endpoints
	void Update () {
        // get pos
        endPoints[0] = player.transform.position;
        endPoints[1] = cursor.transform.position;

        // set pos
        line.SetPositions(endPoints);
    }
}
