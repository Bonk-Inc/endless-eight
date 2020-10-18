using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ConversationPlayer : MonoBehaviour
{
    private List<GameObject> personToTalkTo;

    [SerializeField] private PopUpBehaviour popUpBehaviour;

    [SerializeField]
    private CharacterInfo playerInfo;

    [SerializeField]
    private DialogueTreePlayer player;

    [SerializeField]
    private GameObject eToTalkButton;

    public DialogueTreePlayer Player => player;

    void Start()
    {
        personToTalkTo = new List<GameObject>();
    }

    void Update()
    {
        checkInput();
    }

    private void checkInput(){
        eToTalkButton.SetActive(personToTalkTo.Count > 0);

        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) && personToTalkTo.Count != 0)
        {
            findOutWhichPersonToTalkTo();
        }   
    }

    public void TalkTopeople(GameObject personToInteractWith)
    {
        // TODO talk to the person to interact with.
        DialogueCharacter character = personToInteractWith.GetComponent<DialogueCharacter>();//TODO choose interaction
        StartDialogue(character);
    }

    public void StartDialogue(DialogueCharacter character, Action OnSpecificDialogueEnded = null)
    {
        DialogueTree tree = character.GetDialogue();
        tree.SetCharacters(new CharacterInfo[] { playerInfo, character.GetCharacter() });
        player.PlayTree(tree, OnSpecificDialogueEnded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("InteractablePerson"))
            personToTalkTo.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("InteractablePerson"))
        {
            personToTalkTo.Remove(other.gameObject);
            if (personToTalkTo.Count < 2)
            {
                popUpBehaviour.DisablePopUp();
            }
        }
    }

    private void findOutWhichPersonToTalkTo()
    {
        KillablePerson[] killablePpl = new KillablePerson[10];
        for (int i = 0; i < personToTalkTo.Count; i++)
        {
            killablePpl[i] = personToTalkTo[i].GetComponent<KillablePerson>();
        }
        //TODO UI met plaatjes van alle mensen en vervolgens dan op kunnen laten drukken.

        popUpBehaviour.ShowPopUp(killablePpl);
    }
}