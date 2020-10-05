using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PossibleTarget
{
    [SerializeField]
    private DialogueTree targetHint;
    [SerializeField]
    private KillablePerson target;

    public DialogueTree TargetHint => targetHint;
    public KillablePerson Target => target;
}
