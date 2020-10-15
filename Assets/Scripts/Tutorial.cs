using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] 
    private DialogueTreePlayer treePlayer;
    [SerializeField] 
    private DialogueTree dialogueTree;
    [SerializeField]
    private string nextScene = "start";

    private void Start()
    {
        treePlayer.PlayTree(dialogueTree);
    }


    private void Update()
    {
        changeScene();
    }

    private void changeScene() {
        if(!treePlayer.IsInDialogue)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
