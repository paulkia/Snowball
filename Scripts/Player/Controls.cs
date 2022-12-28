using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public static readonly KeyCode
        // P1 Controls
        p1Right = KeyCode.RightArrow,
        p1Left = KeyCode.LeftArrow,
        p1Up = KeyCode.UpArrow,
        p1Down = KeyCode.DownArrow,
        p1Shoot = KeyCode.Period,
        // P2 Controls
        p2Right = KeyCode.D,
        p2Left = KeyCode.A,
        p2Up = KeyCode.W,
        p2Down = KeyCode.S,
        p2Shoot = KeyCode.R;

    public bool wasd;

    public KeyCode rightKey() {
        return wasd ? p2Right : p1Right;
    }

    public KeyCode leftKey() {
        return wasd ? p2Left : p1Left;
    }

    public KeyCode upKey() {
        return wasd ? p2Up : p1Up;
    }

    public KeyCode downKey() {
        return wasd ? p2Down : p1Down;
    }

    public KeyCode shootKey() {
        return wasd ? p2Shoot : p1Shoot;
    }

    public bool right() {
        return Input.GetKey(rightKey());
    }

    public bool left() {
        return Input.GetKey(leftKey());
    }

    public bool up() {
        return Input.GetKey(upKey());
    }

    public bool down() {
        return Input.GetKey(downKey());
    }

    public bool shoot() {
        return Input.GetKey(shootKey());
    }

    public bool rightKeyDown() {
        return Input.GetKeyDown(rightKey());
    }

    public bool leftKeyDown() {
        return Input.GetKeyDown(leftKey());
    }

    public bool upKeyDown() {
        return Input.GetKeyDown(upKey());
    }

    public bool downKeyDown() {
        return Input.GetKeyDown(downKey());
    }

    public bool shootKeyDown() {
        return Input.GetKeyDown(shootKey());
    }
}
