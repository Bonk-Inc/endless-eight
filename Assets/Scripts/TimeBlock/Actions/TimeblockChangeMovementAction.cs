using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeblockChangeMovementAction : TimeblockActionManager
{

    [SerializeField]
    private Transform morningPosition, afternoonPosition, eveningPosition;

    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        switch (newTimeblock)
        {
            case TimeBlockType.MORNING:
                transform.position = morningPosition.transform.position;
                break;
            case TimeBlockType.AFTERNOON:
                transform.position = afternoonPosition.transform.position;
                break;
            case TimeBlockType.EVENING:
                transform.position = eveningPosition.transform.position;
                break;
            default:
                break;
        }
    }

}
