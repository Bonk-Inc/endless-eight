using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 500)] private float speedUpDown;
    [SerializeField] [Range(0, 500)] private float speedLeftRight;
    [SerializeField] private AudioSource walking1;
    [SerializeField] private AudioSource walking2;

    private bool isGrounded;

    [SerializeField]
    private DialogueTreePlayer dialogue;
    [SerializeField]
    private GameObject timeblockPupup;


    public bool CanMove
    {
        get
        {
            return !dialogue.IsInDialogue && !timeblockPupup.activeSelf;
        }
    }

    private AudioSource RandomAudioSource()
    {
        float rand = UnityEngine.Random.Range(0f, 1f);
        return rand < 0.5f ? walking1 : walking2;
    }

    public void Move(bool left, bool right, bool up, bool down)
    {
        if (!CanMove)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        if ((left || right || up || down))
        {
            if (!(walking1.isPlaying || walking2.isPlaying)) RandomAudioSource().Play();


        }
        else
        {
            walking1.Stop();
            walking2.Stop();
        }


        Vector3 velocity = new Vector2();

        if (left) velocity = new Vector3(speedLeftRight, 0, 0);
        if (right) velocity += new Vector3(-speedLeftRight, 0, 0);
        if (up) velocity += new Vector3(0, 0, speedUpDown);
        if (down) velocity += new Vector3(0, 0, -speedUpDown);

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;

        if (rb.velocity != Vector3.zero)
        {
            Vector3 angle = Vector3.up * Vector3.SignedAngle(Vector3.back, rb.velocity, Vector3.up);
            transform.rotation = Quaternion.Euler(angle);
        }
        

    }
}
