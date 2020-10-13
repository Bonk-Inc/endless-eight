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
                transform.rotation = morningPosition.transform.rotation;
                break;
            case TimeBlockType.AFTERNOON:
                transform.position = afternoonPosition.transform.position;
                transform.rotation = afternoonPosition.transform.rotation;
                break;
            case TimeBlockType.EVENING:
                transform.position = eveningPosition.transform.position;
                transform.rotation = eveningPosition.transform.rotation;
                break;
            default:
                break;
        }
    }

}
