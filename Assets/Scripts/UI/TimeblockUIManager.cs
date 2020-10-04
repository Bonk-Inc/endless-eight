using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeblockUIManager : TimeblockActionManager
{

    [SerializeField]
    private Sprite morning, afternoon, evening;

    [SerializeField]
    private Image timeblockUI;

    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        switch (newTimeblock)
        {
            case TimeBlockType.MORNING:
                timeblockUI.sprite = morning;
                break;
            case TimeBlockType.AFTERNOON:
                timeblockUI.sprite = afternoon;
                break;
            case TimeBlockType.EVENING:
                timeblockUI.sprite = evening;
                break;
            default:
                break;
        }
    }
}
