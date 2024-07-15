using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour {
    // configs
    public Text countText;
    public Text countMass;
    public Text gameOver;
    public float massGain;
    int counter;

    // fields
    Rigidbody2D body;

	// Use this for initialization
	void Awake () {
        body = GetComponent<Rigidbody2D>();
        counter = 0;

        // init text
        countText.text = "Score: " + counter.ToString();
        countMass.text = "Mass: " + body.mass.ToString();
        gameOver.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        // increment score
        counter++;

        // mass changes
        int mod = 1;
        if (other.gameObject.CompareTag("reduce")) {
            mod = -1;
        }
        body.mass = Mathf.Max(body.mass + massGain * mod,2);

        if (body.mass < 0) body.mass = 1;

        // update score
        countText.text = "Score: " + counter.ToString();
        countMass.text = "Mass: " + body.mass.ToString();
    }

    public void Snapped() {
        // Game over
        countText.enabled = false;
        countMass.enabled = false;
        gameOver.enabled = true;
        gameOver.text = "Snapped!\nScore: " + counter.ToString();
    }
}
