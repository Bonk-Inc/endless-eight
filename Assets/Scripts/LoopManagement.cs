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
    private CameraLoopColor camera;

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
            timer.Pause = true;
            ChangePositionsPeople();
            dialogueText.SetDistortionLevel(loopNumber - 1);

            loopUIDisplay.SetText(Mathf.Max(lastLoop - loopNumber, 0).ToString());
            cameraMovement.SetPositionToTarget();
            camera.SetLoop(loopNumber, lastLoop);
        }));
        
        
    }

    private void ChangePositionsPeople()
    {
        player.position = spawnposition.position;

        playerDialogue.StartDialogue(hintDiaCharacter, () =>
        {
            timer.Pause = true;
            playerDialogue.StartDialogue(startingDiaCharacter);
        }); 
    }

    public IEnumerator FadeToReset(Action reset)
    {
        yield return StartCoroutine(loopResetFade.FadeTo(1, reset));
        yield return StartCoroutine(loopResetFade.FadeTo(0));
    }

}
