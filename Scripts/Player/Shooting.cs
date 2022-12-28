using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D blueRb;
    public GameObject bulletPrefab;
    public Controls controls;
    private int cooldown = 0;
    private readonly float margin = 0.3f,
         snowballSpeedFactor = 2.2f;
    public Status stat;

    void Update() {
        if (cooldown-- > 0) return;
        if (controls.shootKeyDown() && stat.snow > 33) {
            Shoot();
            stat.decreaseSnow(33);
            cooldown = 15;
        }
    }

    void Shoot() {
        // state for x and y components of snowball direction
        int x = 0, y = 0;
        // if horizontal movement, or no vertical movement, shoot horizontally at least
        if (controls.left() || controls.right() || !(controls.up() || controls.down()))
            // looking to left or right
            x = transform.localScale.x < 0 ? 1 : -1;
        if (controls.up()) y = 1;
        else if (controls.down()) y = -1;
        // creates snowball
        GameObject snowball = Instantiate(bulletPrefab, blueRb.position + new Vector2(x * margin, (y - 0.25f) * margin), new Quaternion());
        // sets snowball velocity given x, y direction components and snowball speed factor
        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x, y) * NormalizedSpeed(x, y, snowballSpeedFactor), ForceMode2D.Impulse);
    }

    // Prevents physics bug.
    // Essentially, if x is 1 and y is 0, speed would be 1.
    // If y is 1 and x is 0, speed would also be 1.
    // But if x and y are both 1, speed by pythagorean theorem would be sqrt(2).
    // In reality, diagonal speed should still be 1, but it would be slightly more than 1.
    // This method normalizes the speed so that it is the same regardless of direction.
    private float NormalizedSpeed(int x, int y, float speed) {
        return speed / Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }
}
