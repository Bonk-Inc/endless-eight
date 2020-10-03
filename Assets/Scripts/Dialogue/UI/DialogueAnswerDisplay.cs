using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnswerDisplay : MonoBehaviour
{
    [SerializeField]
    private RectTransform answerContent;

    [SerializeField]
    private AnswerButton buttonPrefab;

    [SerializeField]
    private DialogueCharacterDisplay characterDisplay;

    public void ShowAnswers(DialogueAnswer[] answer, CharacterInfo character, Action<DialogueTree> answerChosen)
    {
        answerContent.gameObject.SetActive(true);
        for (int i = 0; i < answer.Length; i++)
        {
            CreateAnswerButton(answer[i], answerChosen);
        }
        characterDisplay.ShowCharacter(character);
        
    }

    private void CreateAnswerButton(DialogueAnswer answer, Action<DialogueTree> answerChosen)
    {
        AnswerButton button = Instantiate(buttonPrefab);
        button.SetAnswer(answer);
        button.OnAnswerChosen += (caller, args) =>
        {
            answerChosen.Invoke(args.nextTree);
            RemoveAnswers();
            answerContent.gameObject.SetActive(false);
        };
        button.transform.SetParent(answerContent);
    }

    private void RemoveAnswers()
    {
        for (int i = 0; i < answerContent.childCount; i++) {
            Destroy(answerContent.GetChild(i).gameObject);
        }
    }


}
