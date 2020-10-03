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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) up = true;
        else if (Input.GetKey(KeyCode.S)) down = true;

        if (Input.GetKey(KeyCode.A)) right = true;
        else if (Input.GetKey(KeyCode.D)) left = true;


    }
    private void FixedUpdate()
    {
        controller.Move(left, right, up, down);
        up = false;
        down = false;
        right = false;
        left = false;
    }
}
