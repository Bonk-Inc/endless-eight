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
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        timeRemaining = (maxTime - time);
        
        pro.SetText(Math.Floor(timeRemaining).ToString());
        time += Time.deltaTime;
        if (timeRemaining <= 0)
        {
            time = 0;
            outOfTime?.Invoke();
            
        }
    }
}
