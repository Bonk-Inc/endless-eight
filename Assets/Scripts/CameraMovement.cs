using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float cameraSpeed = 0.1f;
    [SerializeField] private Vector3 offset;

    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp((gameObject.transform.position), player.transform.position + offset, cameraSpeed);
    }

    public void SetPositionToTarget()
    {
        gameObject.transform.position = player.transform.position + offset;
    }
}
