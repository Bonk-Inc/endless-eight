using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaFader : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private float minDiff = 0.01f;

    [SerializeField]
    private float lerpSpeed = 0.01f;

    public IEnumerator FadeTo(float alpha, Action fadeFinished = null)
    {

        image.gameObject.SetActive(true);
        while (Mathf.Abs(image.color.a - alpha) > minDiff)
        {
            ChangeAlpha(Mathf.Lerp(image.color.a, alpha, lerpSpeed * Time.deltaTime));
            yield return null;
        }
        ChangeAlpha(alpha);

        if (alpha <= 0)
            image.gameObject.SetActive(false);

        fadeFinished?.Invoke();
    }

    private void ChangeAlpha(float a)
    {
        Color newColor = image.color;
        newColor.a = a;
        image.color = newColor;
    }

}
