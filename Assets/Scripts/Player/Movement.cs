using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private PlayerController controller;
    private bool left;
    private bool right;
    private bool up;
    private bool down;

    void Update()
    {
        CheckInput();
    }

    private void CheckInput(){
        if (Input.GetKey(KeyCode.W)) up = true;
        else if (Input.GetKey(KeyCode.S)) down = true;

        if (Input.GetKey(KeyCode.A)) right = true;
        else if (Input.GetKey(KeyCode.D)) left = true;
    }

    private void FixedUpdate()
    {
        ManageController();
    }

    private void ManageController(){
        controller.Move(left, right, up, down);
        up = false;
        down = false;
        right = false;
        left = false;
    }
}
