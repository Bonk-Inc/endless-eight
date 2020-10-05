using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopUpBehaviour : MonoBehaviour
{
    [SerializeField] List<KillTalkUI> interactionUI;
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

                interactionUI[counterButtons].Activate(person.sprite, () =>
                {
                    DisablePopUp();
                    person.Kill();
                },
                () => {
                    DisablePopUp();
                    conversationPlayer.TalkTopeople(person.gameObject);
                });
                counterButtons++;
            }
        }
    }


    public void DisablePopUp()
    {
        foreach (KillTalkUI interactionButtons in interactionUI)
        {
            interactionButtons.Deactivate();
        }
    }

}
