using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBlock : MonoBehaviour
{
    [SerializeField]
    private NumberRange timeRange;

    [SerializeField]
    private TimeBlockType type;

    public NumberRange TimeRange { get => timeRange; }

    public TimeBlockType Type { get => type; }


    public bool TimeFalseInblock(float time) => timeRange.NumberFallsInRange(time);
}
