using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillablePerson : MonoBehaviour
{
    public event Action OnKilled;
    public Sprite sprite;

    private void Start()
    {
        TargetManagement.Instance.AddPotentialTarget(this);
       
    }

    public virtual void Kill()
    {
        OnKilled?.Invoke();
        
    }
}
