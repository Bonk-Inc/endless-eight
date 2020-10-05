using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float time;
    [SerializeField] private float maxTime;
    [SerializeField]private TextMeshProUGUI pro;
    private float timeRemaining;
    [SerializeField] private UnityEvent outOfTime;

    private bool pause = false;

    public event Action<float> OnTimeChanged;

    private void FixedUpdate()
    {
        if (pause) return;
        timeRemaining = (maxTime - time);
        OnTimeChanged?.Invoke(timeRemaining);
        pro.SetText(Math.Floor(timeRemaining).ToString());
        time += Time.deltaTime;
        if (timeRemaining <= 0)
        {
            time = 0;
            outOfTime?.Invoke();
        }
    }

    public void Pause()
    {
        pause = true;
    }

    public void UnPause()
    {
        pause = false;
    }

    public void ResetTime()
    {
        timeRemaining = maxTime;
        time = 0;
        OnTimeChanged?.Invoke(maxTime);
        pro.SetText(Math.Floor(timeRemaining).ToString());
    }
}
