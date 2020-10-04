using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetManagement : MonoBehaviour
{
    public static TargetManagement Instance { get; private set; }

    [SerializeField]
    private KillablePerson target;

    [SerializeField]
    private UnityEvent OnTargetKilled, OnNonTargetKilled;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        target.OnKilled += OnTargetKilled.Invoke;
    }

    public void AddPotentialTarget(KillablePerson potentialTarget)
    {
        if (target == potentialTarget)
            return;

        potentialTarget.OnKilled += OnNonTargetKilled.Invoke;
    }
}
