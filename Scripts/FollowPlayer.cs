using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Rigidbody2D player, self;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        self.position = new Vector2(player.position.x, player.position.y + 0.34f);
    }
}
