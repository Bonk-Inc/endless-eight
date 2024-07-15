using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PossibleTarget
{
    [SerializeField]
    private int id;
    [SerializeField]
    private int difficulty = 1;
    [SerializeField]
    private DialogueTree targetHint;
    [SerializeField]
    private KillablePerson target;

    public int Id => id;
    public int Difficulty => difficulty;
    public DialogueTree TargetHint => targetHint;
    public KillablePerson Target => target;
}
