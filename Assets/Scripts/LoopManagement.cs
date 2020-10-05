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
    private SingleTreeDialogueCharacter hintDiaCharacter;
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private DistortedDialogueTextDisplay dialogueText;
    [SerializeField]
    private TMPro.TextMeshProUGUI loopUIDisplay;

    private PossibleTarget currentTarget;

    public UnityEvent GameOver;

    private void Start()
    {
        currentTarget = TargetManagement.Instance.CurrentTarget;
        hintDiaCharacter.SetDialogue(currentTarget.TargetHint);

        GoToNextLoop();
    }

    public void GoToNextLoop()
    {
        AddLoopIteration(1);
    }

    public void AddLoopIteration(int amount)
    {
        loopNumber += amount;
        timer.ResetTime();
        timer.Pause();
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

        playerDialogue.StartDialogue(hintDiaCharacter, () =>
        {
            timer.Pause();
            playerDialogue.StartDialogue(startingDiaCharacter);
        }); 
    }

}
