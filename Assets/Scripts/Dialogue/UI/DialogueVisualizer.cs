using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueVisualizer : MonoBehaviour
{

    [SerializeField]
    private DialogueLineTextDisplay lineTextDisply;

    [SerializeField]
    private DialogueCharacterDisplay characterDisplay;

    private Coroutine dialogueLinePlayer;

    public void PlayLines(DialogueLine[] lines, CharacterInfo[] characters)
    {
        if (dialogueLinePlayer != null)
            StopCoroutine(dialogueLinePlayer);

        dialogueLinePlayer = StartCoroutine(PlayDialogueLines(lines, characters));
    }

    private void ShowLine(DialogueLine line, CharacterInfo[] characters)
    {
        lineTextDisply.DisplayLine(line.Line);
        characterDisplay.ShowCharacter(characters[line.Character]);
    }

    private IEnumerator PlayDialogueLines(DialogueLine[] lines, CharacterInfo[] characters)
    {
        foreach (DialogueLine line in lines)
        {
            ShowLine(line, characters);
            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
        }
    }



}
