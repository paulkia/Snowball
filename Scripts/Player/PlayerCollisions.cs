using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {
    public Status stat;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.name.ToLower().Contains("snowball")) {
            stat.getHitBySnowball(collision.gameObject);
        }
    }
}
