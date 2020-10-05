using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{

    [SerializeField] private GameObject gObject;
    public void showCredits()
    {
        gObject.SetActive(true);
    }

    public void hideCredits()
    {
        gObject.SetActive(false);
    }
}
