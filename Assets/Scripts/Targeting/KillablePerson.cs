using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillablePerson : MonoBehaviour
{
    public event Action OnKilled;

    private void Start()
    {
        TargetManagement.Instance.AddPotentialTarget(this);
    }

    public virtual void Kill()
    {
        OnKilled?.Invoke();
    }
}
