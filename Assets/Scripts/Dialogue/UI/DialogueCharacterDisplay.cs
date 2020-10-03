using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCharacterDisplay : MonoBehaviour
{

    [SerializeField]
    private Image portrait;

    [SerializeField]
    private TextMeshProUGUI nameText;

    public void ShowCharacter(CharacterInfo character)
    {
        if (character == null)
        {
            EmptyDisplay();
            return;
        }

        portrait.sprite = character.Portrait;
        nameText.SetText(character.Name);
    }

    private void EmptyDisplay()
    {
        portrait.sprite = null;
        nameText.SetText("");
    }

}
