using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDialogueTextDisplay : DialogueLineTextDisplay
{

    public TMPro.TextMeshProUGUI textDisplay;

    public override void DisplayLine(string line, Action lineFullyDisplayed = null)
    {
        textDisplay.SetText(line);
        lineFullyDisplayed?.Invoke();
    }

}
