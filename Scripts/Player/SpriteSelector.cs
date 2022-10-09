using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteSelector : MonoBehaviour {
    public Controls controls;
    public List<Sprite> sprites;
    private static List<Sprite> availableSprites;
    private static bool p1;
    private static int selection;
    // Start is called before the first frame update
    void Start() {
        availableSprites = new(sprites);
        selection = 0;
        p1 = true;
    }

    // Update is called once per frame
    void Update() {
        // skip if other player is selecting
        if ((controls.wasd && p1) || (!controls.wasd && !p1))
            return;
        // if select skin
        if (controls.shootKeyDown()) {
            if (p1 == false) {
                PlayerPrefs.SetString("Player 2 Sprite", availableSprites[selection].name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            } else {
                PlayerPrefs.SetString("Player 1 Sprite", availableSprites[selection].name);
                availableSprites.RemoveAt(selection);
                selection = 0;
                p1 = false;
                return;
            }
        } else if (controls.rightKeyDown()) {
            changeSelection(1);
        } else if (controls.leftKeyDown()) {
            changeSelection(-1);
        }
        updateSprite();
    }

    private static void changeSelection(int val) {
        selection += val;
        if (selection < 0) selection = availableSprites.Count - 1;
        else if (selection >= availableSprites.Count) selection = 0;
    }
    private void updateSprite() {
        if (selection < availableSprites.Count)
            gameObject.GetComponent<SpriteRenderer>().sprite = availableSprites[selection];
    }
}