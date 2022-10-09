using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSelector : MonoBehaviour {
    public Animator animator;
    public List<Sprite> sprites;
    private Sprite sprite;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        switch (animator.runtimeAnimatorController.name) {
            case "Blue":
                sprite = sprites[0];
                break;
            case "Pink":
                sprite = sprites[1];
                break;
            case "Yellow":
                sprite = sprites[2];
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
