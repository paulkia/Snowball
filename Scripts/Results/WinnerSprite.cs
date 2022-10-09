using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerSprite : MonoBehaviour {
    // Start is called before the first frame update
    public List<Sprite> sprites;
    void Start() {
        int winnerIndex = PlayerPrefs.GetInt("winner index");
        string winnerSprite = PlayerPrefs.GetString("Player " + (winnerIndex + 1) + " Sprite");
        int winnerSpriteIndex = 0;
        if (winnerSprite.Equals("pink_0"))
            winnerSpriteIndex++;
        else if (winnerSprite.Equals("yellow_0"))
            winnerSpriteIndex = 2;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[winnerSpriteIndex];
    }

    // Update is called once per frame
    void Update() {

    }
}
