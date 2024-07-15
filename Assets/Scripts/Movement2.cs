using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2 : MonoBehaviour {
    // Configs
    public float relaxLength;
    public float maxLength;
    public float tensionConstant;
    public GameObject cursor;
    public GameObject lineObject;

    // Fields
    Rigidbody2D body;
    LineRenderer line;
    Gradient grad;
    Vector3 direction = new Vector3(0,0,0);
    float distance = 0;
    bool snap = false;
    bool started = false;

    // Use this for initialization
    void Awake() {
        // get objects
        body = GetComponent<Rigidbody2D>();
        line = lineObject.GetComponent<LineRenderer>();

        // init line color
        InitLineColor();
    }

    // Update is called once per frame
    void Update() {
        // check distance
        Vector3 temp = transform.position - cursor.transform.position;
        distance = temp.magnitude;
        direction = temp.normalized;

        // set line color
        UpdateLineColor();

        // set states
        if (!started && distance < maxLength) {
            started = true;
            line.enabled = true;
        }
        if (started && !snap && distance > maxLength) StartCoroutine(Snap());
    }

    void FixedUpdate() {
        // do nothing if not started or had ended
        if (snap || !started) return;

        // add force according to Moore's law
        float force = -Mathf.Max(distance - relaxLength, 0) * tensionConstant;
        body.AddForce(direction * force);
    }

    // snapped, game ended. restart after 3s
    IEnumerator Snap() {
        // game over
        snap = true;
        line.enabled = false;
        PlayerLogic script = GetComponent<PlayerLogic>();
        script.SendMessage("Snapped");

        // restart
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }

    void InitLineColor() {
        // set color and gradient
        Color c1 = Color.white;
        Color c2 = Color.red;

        line.startColor = c1;
        line.endColor = c1;

        grad = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[2];
        colorKey[0].color = c1;
        colorKey[1].color = c2;
        colorKey[0].time = 0f;
        colorKey[1].time = 1f;
        grad.colorKeys = colorKey;
    }

    void UpdateLineColor() {
        // the longer the stretch, more red it would be
        line.startColor = grad.Evaluate(Mathf.Min(distance / maxLength, 1));
        line.endColor = grad.Evaluate(Mathf.Min(distance / maxLength, 1));
    }
}
