using UnityEngine;
using UnityEngine.SceneManagement;

public class Status : MonoBehaviour {
    public Controls controls;
    private const float
        // Bounds of % cold of a player. Invariant: in subset of range [0, 100]
        maxCold = 100, minCold = 0.5f,
        // Bounds of % snow collected by a player. Invariant: in subset of range [0, 100]
        maxSnow = 100, minSnow = 0,
        // sf * max(speed.x, speed.y) = snow collected by player per frame
        snowFactor = 0.01f,
        // each frame, player's cold value decreases by warmingRate percent
        warmingRate = 0.002f;
    public float
        // percentages of cold and snow statuses of players. Invariant: in subset of range [0, 100]
        cold, snow; 
    public Rigidbody2D Player;

    // Start is called before the first frame update
    void Start() {
        cold = 0;
        snow = 0;
    }

    // Update is called once per frame
    void Update() {
        // if collision, cold++
        if (cold == maxCold) {
            PlayerPrefs.SetInt("winner index", controls.wasd ? 0 : 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        if (cold > minCold) cold -= warmingRate;
        if (snow < maxSnow) snow += snowFactor * Mathf.Max(Mathf.Abs(Player.velocity.x), Mathf.Abs(Player.velocity.y));
    }

    public void getHitBySnowball(GameObject snowball) {
        cold = Mathf.Min(maxCold, cold + 20);
    }

    public void decreaseSnow(float val) {
        snow = Mathf.Max(minSnow, snow - val);
    }
}
