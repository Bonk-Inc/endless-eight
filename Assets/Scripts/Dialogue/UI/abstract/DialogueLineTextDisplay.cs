using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueLineTextDisplay : MonoBehaviour
{
    public abstract void DisplayLine(string line, Action lineFullyDisplayed = null);
}
