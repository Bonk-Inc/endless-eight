using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopUpBehaviour : MonoBehaviour
{
    [SerializeField] List<Button> buttons;
    private KillablePerson[] objectArray;
    [SerializeField] ConversationPlayer conversationPlayer;

    private void Start()
    {
        foreach (Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }


    }
    public void ShowPopUp(KillablePerson[] objectArray)
    {
        this.objectArray = objectArray;
        int counterButtons = 0;
        foreach (KillablePerson person in objectArray)
        {
            if (person != null)
            {
                buttons[counterButtons].image.sprite = person.sprite;
                buttons[counterButtons].gameObject.SetActive(true);
                counterButtons++;
            }
        }
    }

    public void OnClick(GameObject buttonGameObject)
    {
        Button buttonClicked = null;
        foreach (Button button in buttons)
        {
            if (button.gameObject == buttonGameObject)
            {
                buttonClicked = button;
                break;
            }

        }
        if (buttonClicked == null)
        {
            Debug.Log("buttonClicked is null. Er gaa tyiets heeeelemaal mis");
            return;
        }
        foreach (KillablePerson killablePerson in objectArray)
        {
            if (killablePerson != null)
            {
                if (buttonClicked.image.sprite == killablePerson.sprite)
                {
                    conversationPlayer.TalkTopeople(killablePerson.gameObject);
                }
            }
        }
    }


    public void DisablePopUp()
    {
        foreach (Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

}
