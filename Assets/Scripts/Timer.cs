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

    public bool Pause{
        get{ return pause; }
        set{ pause = value; }
    }

    public float MaxTime => maxTime;
    public float CurrentTime => time;
    public float TimeRemaining => timeRemaining;


    public event Action<float> OnTimeChanged;

    private void FixedUpdate()
    {
        UpdateTimer();
    }

    private void UpdateTimer(){
        if (pause) return;
        timeRemaining = (maxTime - time);

        pro.SetText(Math.Floor(timeRemaining).ToString());
        time += Time.fixedDeltaTime;
        
        OnTimeChanged?.Invoke(timeRemaining);
        
        if (timeRemaining <= 0)
        {
            time = 0;
            outOfTime?.Invoke();
        }
    }

    public void ResetTime()
    {
        timeRemaining = maxTime;
        time = 0;
        OnTimeChanged?.Invoke(maxTime);
        pro.SetText(Math.Floor(timeRemaining).ToString());
    }
}
