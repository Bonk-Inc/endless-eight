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
    private Sprite afternoonSprite, eveningsprite;

    [SerializeField]
    private Timer timer;


    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        if (newTimeblock == TimeBlockType.AFTERNOON)
        {
            popup.OpenPopup(afternoonText, afternoonSprite);
            timer.Pause();
        }
        else if (newTimeblock == TimeBlockType.EVENING)
        {
            popup.OpenPopup(eveningText, eveningsprite);
            timer.Pause();
        }


    }

}
