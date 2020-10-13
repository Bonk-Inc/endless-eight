using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTreeDialogueCharacter : DialogueCharacter
{
    [SerializeField]
    private DialogueTree dialogueTree;

    public override DialogueTree GetDialogue()
    {
        return dialogueTree;
    }

    public void SetDialogue(DialogueTree dialogueTree)
    {
        this.dialogueTree = dialogueTree;
    }

}
