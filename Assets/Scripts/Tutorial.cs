using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private DialogueTreePlayer treePlayer;
    [SerializeField] private DialogueTree dialogueTree;

    void Start()
    {
        Debug.Log("k");
        treePlayer.PlayTree(dialogueTree);
    }


    void Update()
    {
        if(!treePlayer.IsInDialogue)
        {
            SceneManager.LoadScene("play");
        }
    }
}
