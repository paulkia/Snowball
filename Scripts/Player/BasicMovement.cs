using UnityEngine;

public class BasicMovement : MonoBehaviour {
    public Animator animator;
    public Rigidbody2D rb;
    public Controls controls;

    private const float
        speedChangeFactor = 0.001f, // each update, a keydown changes speed by this much
        horizontalFactor = 2, // how much more important a horizontal keydown is versus vertical
        maximumSpeed = 0.75f, // maximum speed of each player
        // maximum speeds for each direction
        horizontalMax = horizontalFactor * maximumSpeed,
        verticalMax = horizontalFactor * maximumSpeed,
        horizontalSpeedChangeFactor = horizontalFactor * speedChangeFactor,
        verticalSpeedChangeFactor = speedChangeFactor; // hscf or vscf + h or v = next h, next v

    private float horizontal, vertical; // current speeds for each direction

    private void Start() {
        horizontal = 0;
        vertical = 0;
    }

    // Update is called once per frame
    void Update() {
        int horizontalAnimation = 0, verticalAnimation = 0;
        horizontal = rb.velocity.x;
        vertical = rb.velocity.y;

        if (controls.right()) {
            changeHorizontalSpeed(horizontalSpeedChangeFactor);
            horizontalAnimation = 1;
            if (transform.localScale.x > 0) {
                Vector3 abc = transform.localScale;
                abc.x *= -1;
                transform.localScale = abc;
            }
        } else if (controls.left()) {
            changeHorizontalSpeed(-1 * horizontalSpeedChangeFactor);
            horizontalAnimation = -1;
            if (transform.localScale.x < 0) {
                Vector3 tmp = transform.localScale;
                tmp.x *= -1;
                transform.localScale = tmp;
            }
        } else {
            slowDownHorizontal();
        }
        if (controls.up()) {
            changeVerticalSpeed(verticalSpeedChangeFactor);
            verticalAnimation = 1;
        } else if (controls.down()) {
            changeVerticalSpeed(-1 * verticalSpeedChangeFactor);
            verticalAnimation = -1;
        } else {
            slowDownVertical();
        }

        animator.SetFloat("Horizontal", horizontalAnimation);
        animator.SetFloat("Vertical", verticalAnimation);

        rb.velocity = new Vector2(horizontal, vertical);
    }


    // changes horizontal speed by given key
    private void changeHorizontalSpeed(float change) {
        if ((change > 0 && horizontal < horizontalMax) || (change < 0 && horizontal > horizontalMax * -1))
            horizontal += change;
    }
    // changes vertical speed by given key
    private void changeVerticalSpeed(float change) {
        if ((change > 0 && vertical < verticalMax) || (change < 0 && vertical > verticalMax * -1))
            vertical += change;
    }

    private void slowDownHorizontal() {
        if (horizontal > 0.05) {
            changeHorizontalSpeed(-1 * horizontalSpeedChangeFactor);
        } else if (horizontal < -0.05) {
            changeHorizontalSpeed(horizontalSpeedChangeFactor);
        } else horizontal = 0;
    }

    private void slowDownVertical() {
        if (vertical > 0.05) {
            changeVerticalSpeed(-1 * verticalSpeedChangeFactor);
        } else if (vertical < -0.05) {
            changeVerticalSpeed(verticalSpeedChangeFactor);
        } else vertical = 0;
    }
}
