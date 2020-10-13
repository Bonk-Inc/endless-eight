using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    [SerializeField]
    private Button button;

    [SerializeField]
    private TMPro.TextMeshProUGUI textDisplay;

    public event EventHandler<OnAnswerButtonClicked> OnAnswerChosen;

    public void SetAnswer(DialogueAnswer answer)
    {
        textDisplay.SetText(answer.Answer);
        button.onClick.AddListener(() =>
        {
            OnAnswerChosen.Invoke(this, new OnAnswerButtonClicked() { nextTree = answer.NextTree });
        });
    }

        
    public class OnAnswerButtonClicked : EventArgs
    {
        public DialogueTree nextTree;
    }


}
