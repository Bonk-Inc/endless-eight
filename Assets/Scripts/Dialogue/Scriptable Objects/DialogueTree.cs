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

    public CharacterInfo[] characters;

    public DialogueLine[] Lines => lines;
    public DialogueAnswer[] Answers => answers;

    public CharacterInfo[] Characters => characters;

    [SerializeField] private bool keepDefaultCharacters;

    public void SetCharacters(CharacterInfo[] characters)
    {
        if (keepDefaultCharacters) return;
        this.characters = characters;
    }
}
