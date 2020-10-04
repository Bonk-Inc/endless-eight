﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class ConversationPlayer : MonoBehaviour
{
    private List<GameObject> personToTalkTo;

    [SerializeField]
    private CharacterInfo playerInfo;

    [SerializeField]
    private DialogueTreePlayer player;

    // Start is called before the first frame update
    void Start()
    {
        personToTalkTo = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) && personToTalkTo.Count != 0)
        {

            if (personToTalkTo.Count > 1) TalkTopeople(findOutWhichPersonToTalkTo());
            else TalkTopeople(personToTalkTo[0]);
        }
    }

    private void TalkTopeople(GameObject personToInteractWith)
    {
        // TODO talk to the person to interact with.
        DialogueCharacter character = personToInteractWith.GetComponent<DialogueCharacter>();//TODO choose interaction
        StartDialogue(character);
    }

    public void StartDialogue(DialogueCharacter character)
    {
        DialogueTree tree = character.GetDialogue();
        tree.SetCharacters(new CharacterInfo[] { playerInfo, character.GetCharacter() });
        player.PlayTree(tree);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("InteractablePerson"))
            personToTalkTo.Add(other.gameObject);
       
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag.Equals("InteractablePerson"))
            personToTalkTo.Remove(other.gameObject);
      
    }

    private GameObject findOutWhichPersonToTalkTo()
    { //TODO UI met plaatjes van alle mensen en vervolgens dan op kunnen laten drukken.
        return personToTalkTo[0];
    }



}
