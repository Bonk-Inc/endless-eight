using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DistortedDialogueTextDisplay : DialogueLineTextDisplay
{

    [SerializeField]
    private string distortionSigns = "@#&\\";

    [SerializeField]
    private float maxDistortion = 0.1f;

    [SerializeField]
    private int distortionLevel = 10;

    [SerializeField]
    private TMPro.TextMeshProUGUI textDisplay;

    public override void DisplayLine(string line, Action lineFullyDisplayed = null)
    {
        line = DistortLine(line);
        textDisplay.SetText(line);
        lineFullyDisplayed?.Invoke();
    }

    private string DistortLine(string line)
    {
        float distortionRatio = Mathf.Min(0.01f * distortionLevel, maxDistortion);
        StringBuilder lineBuider = new StringBuilder(line);
        for (int i = 0; i < line.Length; i++)
        {
            if (UnityEngine.Random.Range(0f, 1f) > distortionRatio)
                continue;

            lineBuider[i] = GetRandomDistortedChar();
        }
        return lineBuider.ToString();
    }

    private char GetRandomDistortedChar()
    {
        int charIndex = UnityEngine.Random.Range(0, distortionSigns.Length - 1);
        return distortionSigns[charIndex];
    }

    public void SetDistortionLevel(int level)
    {
        distortionLevel = level;
    }
}
