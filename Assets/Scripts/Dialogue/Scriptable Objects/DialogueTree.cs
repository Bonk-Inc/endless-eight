using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueTree", order = 1)]
public class DialogueTree : ScriptableObject
{
    [SerializeField]
    private DialogueLine[] lines;
    [SerializeField]
    private DialogueAnswer[] answers;

    private DialogueLine[] Lines => lines;
    private DialogueAnswer[] Answers => answers;
}
