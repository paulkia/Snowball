using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerText : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> sprites;
    void Start() {
        int spriteIndex = PlayerPrefs.GetInt("winner index");
        Sprite sprite = sprites[spriteIndex];
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // Update is called once per frame
    void Update() {

    }
}
