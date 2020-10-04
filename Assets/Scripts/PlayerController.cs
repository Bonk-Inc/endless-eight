using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 500)] private float speedUpDown;
    [SerializeField] [Range(0, 500)] private float speedLeftRight;

    private bool isGrounded;

    [SerializeField]
    private DialogueTreePlayer dialogue;
    [SerializeField]
    private GameObject timeblockPupup;


    public bool CanMove {
        get
        {
            return !dialogue.IsInDialogue && !timeblockPupup.activeSelf;
        }
    }


    public void Move(bool left, bool right, bool up, bool down)
    {
        if (!CanMove)
            return;

        Vector3 velocity = new Vector2();

        if (left) velocity = new Vector3(speedLeftRight,0,0);
        if (right) velocity += new Vector3(-speedLeftRight, 0,0);
        if (up) velocity += new Vector3(0,0, speedUpDown);
        if (down) velocity += new Vector3(0,0, -speedUpDown);

        gameObject.GetComponent<Rigidbody>().velocity = velocity;

    }
}
