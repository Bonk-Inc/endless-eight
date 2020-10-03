using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueCharacter : MonoBehaviour
{

    [SerializeField]
    protected CharacterInfo dialogueInfo;

    public virtual CharacterInfo GetCharacter()
    {
        return dialogueInfo;
    }

    public abstract DialogueTree GetDialogue();

    
}
