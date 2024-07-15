using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour {
    // configs
    public GameObject target;
    public BoundingCollider playground;
    public int foodNumbers;
    public float redChance;

    // fields
    List<Vector2> boundBox;
    float x0, y0, x1, y1;

    // Use this for initialization
    void Start () {
        // get boundary points
        boundBox = playground.boundaryPoints;
        x0 = boundBox[0].x;
        x1 = boundBox[2].x;
        y0 = boundBox[0].y;
        y1 = boundBox[1].y;

        // summon
        for (int i=0;i<foodNumbers;i++) {
            // generate random position
            Generate();
        }
	}

    void Generate() {
        // randomize pos
        Vector3 pos = new Vector3(Random.Range(x0, x1), Random.Range(y0, y1), 0);

        // instantiate
        GameObject go = Instantiate(target, pos, transform.rotation) as GameObject;
        go.GetComponent<FoodLogic>().generator = gameObject;

        // randomize food type
        if (Random.Range(0f, 1f) < redChance) {
            go.tag = "reduce";
        } else {
            go.tag = "gain";
        }
    }

    // when a food destroyed, recreate after 3 sec
    IEnumerator Recreate() {
        yield return new WaitForSeconds(3);
        Generate();
    }
}
