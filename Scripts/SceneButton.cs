using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour {
    private readonly int GAME_SCENE = 6, MUSIC_SCENE = 8;
    public enum ButtonName {
        Next,
        Back,
        Skip,
        Exit,
        Music,
        Home,
    }
    public List<Sprite> sprites;
    public ButtonName buttonName;
    private void Update() {
        if (hit()) {
            if (!Input.GetMouseButton(0))
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            else
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            if (Input.GetMouseButtonUp(0))
                switch (buttonName) {
                    case ButtonName.Next:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    case ButtonName.Back:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        break;
                    case ButtonName.Skip:
                        SceneManager.LoadScene(GAME_SCENE);
                        break;
                    case ButtonName.Exit:
                        Debug.Log("quit");
                        Application.Quit();
                        break;
                    case ButtonName.Music:
                        SceneManager.LoadScene(MUSIC_SCENE);
                        break;
                    case ButtonName.Home:
                        SceneManager.LoadScene(0);
                        break;
                }
        }
        else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
    private bool hit() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return hit.collider != null && hit.transform == transform;
    }
}
