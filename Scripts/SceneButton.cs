using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour {
    private int gameScene = 6;
    public enum ButtonName {
        Next,
        Back,
        Skip,
        Exit,
        Home,
    }
    public ButtonName buttonName;
    private void Update() {
        if (Input.GetMouseButtonDown(0)) { // if left button pressed...
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform == transform) {
                switch (buttonName) {
                    case ButtonName.Next:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    case ButtonName.Back:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        break;
                    case ButtonName.Skip:
                        SceneManager.LoadScene(gameScene);
                        break;
                    case ButtonName.Exit:
                        Debug.Log("quit");
                        Application.Quit();
                        break;
                    case ButtonName.Home:
                        SceneManager.LoadScene(0);
                        break;
                }
                
            }
        }
    }
}
