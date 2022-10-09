using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArtSelector : MonoBehaviour {
    public List<RuntimeAnimatorController> controllers;
    // Start is called before the first frame update
    void Start() {
        RuntimeAnimatorController rac = controllers[Mathf.RoundToInt(new System.Random().Next(0, 3))];
        gameObject.GetComponent<Animator>().runtimeAnimatorController = rac;
    }
}
