using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteSelector : MonoBehaviour {
    public Controls controls;
    public List<Sprite> sprites;
    private static List<Sprite> availableSprites;
    private static readonly int MAX_AVAILABLE_SPRITES = 3,
    // max number of players
        MAX_PLAYERS = 2;
    // Index of sprite the player chose.
    private int selection;
    // If a player selects a sprite, they are disabled from further actions
    private bool disable;
    // Start is called before the first frame update
    void Start() {
        availableSprites = new(sprites);
        selection = 0;
        disable = false;
    }

    // Update is called once per frame
    void Update() {
        // prevents a player who already selected from doing anything
        if (disable)
            return;
        // if select skin
        if (controls.shootKeyDown()) {
            // prevent p2 from choosing if p1 chooses concurrently (p1 priority)
            if (controls.wasd && Input.GetKey(Controls.p1Shoot) && availableSprites.Count == MAX_AVAILABLE_SPRITES)
                return;
            PlayerPrefs.SetString(controls.wasd ? "Player 2 Sprite" : "Player 1 Sprite",
                availableSprites[selection].name);
            disable = true;
            updateSprite();
            availableSprites.RemoveAt(selection);
            // if all players have chosen, move to next scene
            if (availableSprites.Count <= MAX_AVAILABLE_SPRITES - MAX_PLAYERS)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // disable is true, return to prevent player from changing state
            return;
        } else if (controls.rightKeyDown()) {
            selection++;
        } else if (controls.leftKeyDown()) {
            selection--;
        }
        // guarantee that the player's new selection is in range
        correctSelection();
        // update the player's sprite based on their selection
        updateSprite();
    }
    private void updateSprite() {
        if (selection < availableSprites.Count)
            gameObject.GetComponent<SpriteRenderer>().sprite = availableSprites[selection];
    }
    // Moves player's selection to a valid index in the mutable availability array
    // Called to prevent invalid state
    private void correctSelection() {
        if (selection < 0) selection = availableSprites.Count - 1;
        else if (selection >= availableSprites.Count) selection = 0;
    }
}