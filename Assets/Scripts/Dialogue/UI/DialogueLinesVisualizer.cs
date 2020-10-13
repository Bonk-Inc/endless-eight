using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLinesVisualizer : MonoBehaviour
{

    [SerializeField]
    private DialogueLineTextDisplay lineTextDisply;

    [SerializeField]
    private DialogueCharacterDisplay characterDisplay;

    private void ShowLine(DialogueLine line, CharacterInfo[] characters)
    {
        lineTextDisply.DisplayLine(line.Line);
        characterDisplay.ShowCharacter(characters[line.Character]);
    }

    public IEnumerator PlayDialogueLines(DialogueLine[] lines, CharacterInfo[] characters)
    {
        lineTextDisply.gameObject.SetActive(true);
        foreach (DialogueLine line in lines)
        {
            ShowLine(line, characters);
            
            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
            yield return null;
        }
        lineTextDisply.gameObject.SetActive(false);
    }



}
