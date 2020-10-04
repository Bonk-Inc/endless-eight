using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopManagement : MonoBehaviour
{
    private int loopNumber;

    [SerializeField]
    private int lastLoop = 8;

    [SerializeField]
    private Transform player, spawnposition;

    [SerializeField]
    private ConversationPlayer playerDialogue;
    [SerializeField]
    private DialogueCharacter startingDiaCharacter;

    [SerializeField]
    private DistortedDialogueTextDisplay dialogueText;
    [SerializeField]
    private TMPro.TextMeshProUGUI loopUIDisplay;

    public UnityEvent GameOver;

    private void Start()
    {
        GoToNextLoop();
    }

    public void GoToNextLoop()
    {
        AddLoopIteration(1);
    }

    public void AddLoopIteration(int amount)
    {
        loopNumber += amount;
        ChangePositionsPeople();
        dialogueText.SetDistortionLevel(loopNumber-1);
        loopUIDisplay.SetText( Mathf.Max(lastLoop - loopNumber, 0).ToString());
        if (loopNumber > lastLoop)
        {
            GameOver.Invoke();
        }
    }

    private void ChangePositionsPeople()
    {
        player.position = spawnposition.position;
        playerDialogue.StartDialogue(startingDiaCharacter);
    }

}
