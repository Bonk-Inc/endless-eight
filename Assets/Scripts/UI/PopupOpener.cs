using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOpener : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI textDisplay;

    public void OpenPopup(string text)
    {
        gameObject.SetActive(true);
        textDisplay.text = text;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
