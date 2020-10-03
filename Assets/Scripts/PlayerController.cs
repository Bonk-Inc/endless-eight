using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 500)] private float speedUpDown;
    [SerializeField] [Range(0, 500)] private float speedLeftRight;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform lowestPointOfGameObject;

    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(lowestPointOfGameObject.position, 0.3f, ground);

        foreach (Collider2D coll in colliders)
        {
            if (coll.gameObject != gameObject)
            {
                isGrounded = true;
            }
            
        }
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
