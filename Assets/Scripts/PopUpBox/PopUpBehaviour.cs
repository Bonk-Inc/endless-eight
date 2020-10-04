using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopUpBehaviour : MonoBehaviour
{
    [SerializeField] List<Button> killButtons;
    [SerializeField] List<Button> talkButtons;
    private KillablePerson[] objectArray;
    [SerializeField] ConversationPlayer conversationPlayer;

    private void Start()
    {
        DisablePopUp();


    }
    public void ShowPopUp(KillablePerson[] objectArray)
    {
        this.objectArray = objectArray;
        int counterButtons = 0;
        foreach (KillablePerson person in objectArray)
        {
            if (person != null)
            {
                killButtons[counterButtons].image.sprite = person.sprite;
                killButtons[counterButtons].gameObject.SetActive(true);
                killButtons[counterButtons].onClick.RemoveAllListeners();
                killButtons[counterButtons].onClick.AddListener(() => {
                    DisablePopUp();
                    person.Kill();
                });

                talkButtons[counterButtons].image.sprite = person.sprite;
                talkButtons[counterButtons].gameObject.SetActive(true);
                talkButtons[counterButtons].onClick.RemoveAllListeners();
                talkButtons[counterButtons].onClick.AddListener(() => {
                    DisablePopUp();
                    conversationPlayer.TalkTopeople(person.gameObject);
                });
                counterButtons++;
            }
        }
    }


    public void DisablePopUp()
    {
        foreach (Button b in killButtons)
        {
            b.gameObject.SetActive(false);
        }

        foreach (Button b in talkButtons)
        {
            b.gameObject.SetActive(false);
        }
    }

}
