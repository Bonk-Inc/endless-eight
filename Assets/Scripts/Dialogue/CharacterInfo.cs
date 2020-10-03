using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterInfo
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Sprite portrait;

    public string Name => name;
    public Sprite Portrait => portrait;

}
