using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueLine : MonoBehaviour
{
    [SerializeField]
    private CharacterInfo character;
    [SerializeField]
    private string line;

    public CharacterInfo Character => character;
    public string Line => line;
}
