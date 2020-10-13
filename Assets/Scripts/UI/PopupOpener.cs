using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupOpener : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI textDisplay;

    [SerializeField]
    private Image buttonimage;

    public void OpenPopup(string text, Sprite sprite)
    {
        gameObject.SetActive(true);
        buttonimage.sprite = sprite;
        textDisplay.text = text;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
