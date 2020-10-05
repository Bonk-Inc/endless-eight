using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandRotator : MonoBehaviour
{

    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Transform rotator;

    [SerializeField]
    private float startRot, endRot;

    private float rotDiff;

    private void Start()
    {
        rotDiff = startRot + (360 - endRot);
        timer.OnTimeChanged += (time) => SetUI();
    }

    private void SetUI()
    {
        float currentTargetRotDiff = rotDiff / timer.MaxTime * timer.CurrentTime;
        SetZRotation(startRot - currentTargetRotDiff);
    }

    private void SetZRotation(float zRot)
    {
        Vector3 rot = rotator.eulerAngles;
        rot.z = zRot;
        rotator.rotation = Quaternion.Euler(rot);
    }




}
