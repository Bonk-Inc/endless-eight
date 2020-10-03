using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DialogueAnswer
{

    [SerializeField]
    private string answer;
    [SerializeField]
    private DialogueTree nextTree;

    public string Answer => answer;
    public DialogueTree NextTree => nextTree;
}
