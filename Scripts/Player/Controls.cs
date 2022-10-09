using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public bool wasd;

    public KeyCode rightKey() {
        return wasd ? KeyCode.D : KeyCode.RightArrow;
    }

    public KeyCode leftKey() {
        return wasd ? KeyCode.A : KeyCode.LeftArrow;
    }

    public KeyCode upKey() {
        return wasd ? KeyCode.W : KeyCode.UpArrow;
    }

    public KeyCode downKey() {
        return wasd ? KeyCode.S : KeyCode.DownArrow;
    }

    public KeyCode shootKey() {
        return wasd ? KeyCode.R : KeyCode.Period;
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
