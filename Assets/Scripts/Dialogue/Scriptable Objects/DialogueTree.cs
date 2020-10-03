using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueTree", order = 1)]
public class DialogueTree : ScriptableObject
{
    [SerializeField]
    private DialogueLine[] lines;
    [SerializeField]
    private string[] answers;
    [SerializeField]
    private DialogueTree nextTree;

    private DialogueLine[] Lines => lines;
    private string[] Answers => answers;
    private DialogueTree NextTree => nextTree;
}
