using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTalkUI : MonoBehaviour
{
    [SerializeField]
    private Button killButton, talkButton;

    [SerializeField]
    private Image portraitUI;

    public void Activate(Sprite portrait, Action OnKill, Action OnTalk)
    {
        gameObject.SetActive(true);

        portraitUI.sprite = portrait;

        killButton.onClick.RemoveAllListeners();
        killButton.onClick.AddListener(() => OnKill.Invoke());

        talkButton.onClick.RemoveAllListeners();
        talkButton.onClick.AddListener(() => OnTalk.Invoke());
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
