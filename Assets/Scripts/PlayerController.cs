using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 500)] private float speedUpDown;
    [SerializeField] [Range(0, 500)] private float speedLeftRight;

    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {

    }
    public void Move(bool left, bool right, bool up, bool down)
    {
        Vector3 velocity = new Vector2();

        if (left) velocity = new Vector3(speedLeftRight,0,0);
        if (right) velocity += new Vector3(-speedLeftRight, 0,0);
        if (up) velocity += new Vector3(0,0, speedUpDown);
        if (down) velocity += new Vector3(0,0, -speedUpDown);

        gameObject.GetComponent<Rigidbody>().velocity = velocity;

    }
}
