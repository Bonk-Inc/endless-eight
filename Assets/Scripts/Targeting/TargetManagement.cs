using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetManagement : MonoBehaviour
{
    public static TargetManagement Instance { get; private set; }

    [SerializeField]
    private PossibleTarget currentTarget;

    [SerializeField]
    private PossibleTarget[] possibleTargets;

    [SerializeField]
    private UnityEvent OnTargetKilled, OnNonTargetKilled;

    public PossibleTarget CurrentTarget => currentTarget;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;

        if(currentTarget.Target == null)
        {
            int targetNumber = Random.Range(0, possibleTargets.Length);
            currentTarget = possibleTargets[targetNumber];
        }

        currentTarget.Target.OnKilled += OnTargetKilled.Invoke;
    }

    public void AddPotentialTarget(KillablePerson potentialTarget)
    {
        if (currentTarget.Target == potentialTarget)
            return;

        potentialTarget.OnKilled += OnNonTargetKilled.Invoke;
    }
}
