using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeblockpopupOpener : TimeblockActionManager
{
    [SerializeField]
    private PopupOpener popup;

    [SerializeField]
    private string afternoonText, eveningText;

    [SerializeField]
    private Timer timer;


    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        if (newTimeblock == TimeBlockType.AFTERNOON)
        {
            popup.OpenPopup(afternoonText);
            timer.Pause();
        }
        else if (newTimeblock == TimeBlockType.EVENING)
        {
            popup.OpenPopup(eveningText);
            timer.Pause();
        }


    }

}
