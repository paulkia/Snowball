using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteInGame : MonoBehaviour {
    public Controls controls;
    // Start is called before the first frame update
    public List<RuntimeAnimatorController> controllers;
    void Start() {
        string animationSelection =
            PlayerPrefs.GetString(controls.wasd ? "Player 2 Sprite" : "Player 1 Sprite");
        int animationSelectionIndex = 0;
        if (animationSelection.Equals("pink_0"))
            animationSelectionIndex = 1;
        else if (animationSelection.Equals("yellow_0"))
            animationSelectionIndex = 2;
        RuntimeAnimatorController rac = controllers[animationSelectionIndex];
        gameObject.GetComponent<Animator>().runtimeAnimatorController = rac;
    }

    // Update is called once per frame
    void Update() {

    }
}
