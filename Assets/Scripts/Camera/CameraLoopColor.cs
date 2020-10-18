using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLoopColor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Color startColor, targetColor;

    public void SetLoop(int loop, int maxloop)
    {
        loop--;
        maxloop--;
        cam.backgroundColor = Color.Lerp(startColor, targetColor, (float)loop / (float)maxloop);
    }

}
