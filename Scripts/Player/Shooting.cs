using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform blue;
    public Rigidbody2D blueRb;
    public GameObject bulletPrefab;
    public Controls controls;
    private float margin = 0.3f;
    public Status stat;

    void Update() {
        if (controls.shootKeyDown() && stat.snow > 10) {
            Shoot();
            stat.decreaseSnow(30);
        }
    }

    void Shoot() {
        float x = 0, y = 0, snowballSpeedFactor = 2.2f;
        // if horizontal movement, or no vertical movement, shoot horizontally at least
        if (controls.left() || controls.right() || !(controls.up() || controls.down()))
            // looking to left or right
            x = transform.localScale.x < 0 ? 1 : -1;
        if (controls.up()) y = 1;
        else if (controls.down()) y = -1;
        Debug.Log("shot");
        GameObject snowball = Instantiate(bulletPrefab, blueRb.position + new Vector2(x * margin, (y - 0.5f) * margin), new Quaternion());
        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x, y) * snowballSpeedFactor, ForceMode2D.Impulse);
    }
}
