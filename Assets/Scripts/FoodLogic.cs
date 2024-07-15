using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLogic : MonoBehaviour {
    // configs
    public GameObject generator;

	// Use this for initialization
	void Awake() {
        // randomize size
        float a = Random.Range(0.1f, 0.5f);
        float b = Random.Range(0.1f, 0.5f);
        transform.localScale = new Vector3(a, b, 1);
    }

    void Start() {
        // set color based on tag
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (gameObject.CompareTag("reduce")) {
            sprite.color = Color.cyan;
        } else if (gameObject.CompareTag("gain")) {
            sprite.color = Color.yellow;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // call recreate to generator
        generator.SendMessage("Recreate");
        Destroy(gameObject);
    }
}
