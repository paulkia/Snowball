using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionSelector : MonoBehaviour {
    public float
        maxX, minX,
        maxY, minY;
    // Start is called before the first frame update
    void Start() {
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

    // Update is called once per frame
    void Update() {

    }
}