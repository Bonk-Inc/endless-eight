using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBlockmanager : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private TimeBlock[] timeBlocks;

    [SerializeField]
    private DialogueTreePlayer dialoguePlayer;

    public TimeBlockType CurrentTimeblock {
        get {
            return currentTimeBlock == null ? TimeBlockType.MORNING : currentTimeBlock.Type;
        }
    }

    public event EventHandler<TimeBlockChangedEvent> OnTimeblockChange;
    private TimeBlock currentTimeBlock;

    private void Awake()
    {
        timer.OnTimeChanged += CheckTimeblock;
        dialoguePlayer.OnDialogueEnded += timer.UnPause;
    }

    private void CheckTimeblock(float time)
    {
        TimeBlock newCurrentBlock = GetTimeblockForTime(time);
        if (newCurrentBlock == null || newCurrentBlock == currentTimeBlock)
            return;


        if (dialoguePlayer.IsInDialogue)
        {
            timer.Pause();
        }
        else
        {
            ChangeTimeblock(newCurrentBlock);
        }

        
    }

    private void ChangeTimeblock(TimeBlock newCurrentBlock)
    {
        OnTimeblockChange?.Invoke(this, new TimeBlockChangedEvent()
        {
            timeBlock = newCurrentBlock.Type
        }); ;
        currentTimeBlock = newCurrentBlock;
    }

    private TimeBlock GetTimeblockForTime(float time)
    {
        for (int i = 0; i < timeBlocks.Length; i++)
        {
            if (!timeBlocks[i].TimeFalseInblock(time))
                continue;

            return timeBlocks[i];
        }
        return null;
    }

    public class TimeBlockChangedEvent : EventArgs
    {
        public TimeBlockType timeBlock;
    }

}


