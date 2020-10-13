using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DialogueLine
{
    [SerializeField]
    private int character;
    [SerializeField]
    private string line;

    public int Character => character;
    public string Line => line;
}
