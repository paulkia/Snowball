using UnityEngine;

// This entire class simply calculates how to update the visual cold UI bar each frame,
// depending on the player's cold status
public class Cold : MonoBehaviour {
    public Status stat;
    private float
        maxPos = 0.0503f, minPos = -0.09246f,
        maxScale = 0.2892734f, minScale = 0;

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
        return ((100 - stat.cold) / 100 * (maxPos - minPos)) + minPos;
    }

    // Given amount of snow collected in this frame, calculates x scale of snow UI in status display
    private float CalculateSnowXScale() {
        return ((100 - stat.cold) / 100 * (maxScale - minScale)) + minScale;
    }
}
