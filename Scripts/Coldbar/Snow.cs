using UnityEngine;

// This entire class simply calculates how to update the visual snow UI bar each frame,
// depending on the player's snow status
public class Snow : MonoBehaviour {
    public Status stat;
    private float
        maxPos = 0.0402f, minPos = -0.09837f,
        maxScale = 0.2892666f, minScale = 0.01193536f;

    // Update is called once per frame
    void Update() {
        Vector3 prevPos = transform.localPosition, prevScale = transform.localScale;
        float nextXPos = CalculateSnowXPos(),
            nextXScale = CalculateSnowXScale();
        transform.localPosition = new Vector3(nextXPos, prevPos.y, prevPos.z);
        transform.localScale = new Vector3(nextXScale, prevScale.y, prevScale.z);
    }

    // Given amount of snow collected in this frame, calculates x position of snow UI in status display
    private float CalculateSnowXPos() {
        return (stat.snow / 100 * (maxPos - minPos)) + minPos;
    }

    // Given amount of snow collected in this frame, calculates x scale of snow UI in status display
    private float CalculateSnowXScale() {
        return (stat.snow / 100 * (maxScale - minScale)) + minScale;
    }
}
