using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    // Configs
    public float speed = 10;

    // Fields
    Rigidbody2D body;
    float move_h, move_v;
    bool update = false;


	// Use this for initialization
	void Start () {
        // get rigidbody
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float x, y;

        // get input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // update if not null
        if (x != 0 || y != 0) {
            move_h = x * speed;
            move_v = y * speed;
            update = true;
        }
    }

    void FixedUpdate() {
        if (update) {
            update = false;
            body.velocity = new Vector2(move_h, move_v);
        }
    }
}
