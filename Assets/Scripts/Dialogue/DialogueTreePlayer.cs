using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTreePlayer : MonoBehaviour
{

    [SerializeField]
    private DialogueLinesVisualizer visualizer;


    public void PlayTree(DialogueTree tree)
    {
        StartCoroutine(PlayDialogueTree(tree));
    }

    private IEnumerator PlayDialogueTree(DialogueTree tree)
    {
        while(tree != null)
        {
            yield return StartCoroutine(visualizer.PlayDialogueLines(tree.Lines, tree.Characters));
            tree = null;
        }

    }
}
