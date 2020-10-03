using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Sprite portrait;

    public string Name => name;
    public Sprite Portrait => portrait;

}
