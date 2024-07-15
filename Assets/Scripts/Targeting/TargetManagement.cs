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

    private string keyPrefex = "targetKilled_";
    private string difficultyKeyPrefex = "targetDifficulty";

    [SerializeField]
    private int possibleDifficulty = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        if (PlayerPrefs.HasKey(difficultyKeyPrefex)) possibleDifficulty = PlayerPrefs.GetInt(difficultyKeyPrefex);

        ChooseTarget();
    }

    private void ChooseTarget()
    {
        List<PossibleTarget> toDoTargets = new List<PossibleTarget>();
        foreach (PossibleTarget target in possibleTargets)
        {
            if(possibleDifficulty >= target.Difficulty && !PlayerPrefs.HasKey(keyPrefex + target.Id)) toDoTargets.Add(target);
        }
        if (toDoTargets.Count == 0) toDoTargets.AddRange(possibleTargets);

        if (currentTarget.Target == null)
        {
            int targetNumber = Random.Range(0, toDoTargets.Count);
            currentTarget = toDoTargets[targetNumber];
        }

        currentTarget.Target.OnKilled += OnTargetKilled.Invoke;
    }

    public void AddPotentialTarget(KillablePerson potentialTarget)
    {
        if (currentTarget.Target == potentialTarget)
            return;

        potentialTarget.OnKilled += OnNonTargetKilled.Invoke;
    }

    public void SaveTargetKill()
    {
        if (PlayerPrefs.HasKey(keyPrefex + currentTarget.Id)) return;
        print("test");
        PlayerPrefs.SetInt(keyPrefex + currentTarget.Id, 1);
        PlayerPrefs.SetInt(difficultyKeyPrefex, possibleDifficulty + 1);
    }
}
