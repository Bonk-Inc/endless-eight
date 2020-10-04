using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NumberRange
{
    [SerializeField]
    private float min, max;

    public float Min { get => min; set => min = value; }
    public float Max { get => max; set => max = value; }

    public bool NumberFallsInRange(float number)
    {
        return number >= min && number <= max;
    }
}
