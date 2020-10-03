using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    [SerializeField]
    private CharacterInfo info;


    [SerializeField]
    private DialogueTreePlayer player;


    private void Update()
    {

        if (!Input.GetKeyDown(KeyCode.E))
            return;

        //TODO replace with actual collider code
        var hits = Physics2D.CircleCastAll(transform.position, 10, transform.forward);
        foreach (var hit in hits)
        {

            DialogueCharacter character = hit.collider.GetComponent<DialogueCharacter>(); ;
            if (character == null)
                continue;

            StartConvorsation(character);
        }
    }

    private void StartConvorsation(DialogueCharacter character)
    {
        DialogueTree tree = character.GetDialogue();
        tree.SetCharacters(new CharacterInfo[] { info, character.GetCharacter() });
        player.PlayTree(tree);
    }


}
