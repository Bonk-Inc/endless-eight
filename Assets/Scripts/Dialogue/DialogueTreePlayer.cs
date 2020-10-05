using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTreePlayer : MonoBehaviour
{

    [SerializeField]
    private DialogueLinesVisualizer lineVisualizer;

    [SerializeField]
    private DialogueAnswerDisplay answerDisplay;

    [SerializeField]
    private Canvas canvas;//TODO this shouldn't be here >:(

    [SerializeField]
    private Timer timer;

    private bool isInDialogue = false;

    public bool IsInDialogue => isInDialogue;

    public event Action OnDialogueEnded, OnCurrentDialogueEnded;


    public void PlayTree(DialogueTree tree, Action OnSpecificDialogueEnded = null)
    {
        if (isInDialogue)
            return;

        StartCoroutine(PlayDialogueTree(tree, OnSpecificDialogueEnded));
    }

    private IEnumerator PlayDialogueTree(DialogueTree tree, Action OnSpecificDialogueEnded = null)
    {
        isInDialogue = true;
        canvas.enabled = true;
        timer?.Pause();
        CharacterInfo answeringCharacter = tree.Characters[0];
        while (tree != null)
        {
            yield return StartCoroutine(lineVisualizer.PlayDialogueLines(tree.Lines, tree.Characters));
            if(tree.Answers.Length > 1) {

                bool answerChosen = false;
                answerDisplay.ShowAnswers(tree.Answers, answeringCharacter, (nextTree) =>
                {
                    answerChosen = true;
                    if (nextTree != null)
                        nextTree.SetCharacters(tree.characters);
                    tree = nextTree;
                });
                while (!answerChosen) yield return null;
            } 
            else if (tree.Answers.Length == 1) {
                DialogueTree nextTree = tree.Answers[0].NextTree;
                nextTree.SetCharacters(tree.characters);
                tree = nextTree;
            }
            else {
                tree = null;
            }
        }
        canvas.enabled = false;
        isInDialogue = false;
        timer?.UnPause();
        OnDialogueEnded?.Invoke();
        OnCurrentDialogueEnded?.Invoke();
        OnCurrentDialogueEnded = null;
        OnSpecificDialogueEnded?.Invoke();
    }
}
