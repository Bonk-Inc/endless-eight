using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
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
    private CameraMovement cameraMovement;

    [SerializeField]
    private Timer timer;

    [SerializeField]
    private DistortedDialogueTextDisplay dialogueText;

    [SerializeField]
    private DialogueTreePlayer dialoguePlayer;
    [SerializeField]
    private TMPro.TextMeshProUGUI loopUIDisplay;

    [SerializeField]
    private ImageAlphaFader loopResetFade;

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
        if (dialoguePlayer.IsInDialogue)
        {
            dialoguePlayer.OnCurrentDialogueEnded += () => AddLoopIteration(amount);
            return;
        }

        loopNumber += amount;
        if (loopNumber > lastLoop)
        {
            GameOver.Invoke();
            return;
        }
        StartCoroutine(FadeToReset(() =>
        {
            timer.ResetTime();
            timer.Pause();
            ChangePositionsPeople();
            dialogueText.SetDistortionLevel(loopNumber - 1);

            loopUIDisplay.SetText(Mathf.Max(lastLoop - loopNumber, 0).ToString());
            cameraMovement.SetPositionToTarget();
        }));
        
        
    }

    private void ChangePositionsPeople()
    {
        print("loop");
        player.position = spawnposition.position;

        playerDialogue.StartDialogue(hintDiaCharacter, () =>
        {
            timer.Pause();
            playerDialogue.StartDialogue(startingDiaCharacter);
        }); 
    }

    public IEnumerator FadeToReset(Action reset)
    {
        yield return StartCoroutine(loopResetFade.FadeTo(1, reset));
        yield return StartCoroutine(loopResetFade.FadeTo(0));
    }

}
