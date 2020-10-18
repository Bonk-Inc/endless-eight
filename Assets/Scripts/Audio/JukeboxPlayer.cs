using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxPlayer : MonoBehaviour
{
    [SerializeField] 
    private AudioSource barMusic;
    [SerializeField] 
    private MusicTimeblockManager timeblockMusic;

    private const float MAX_VOLUME = 0.2f;
    private const float VOLUME_UPDATE = 0.0012f;
    private Coroutine currentCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        
        currentCoroutine = StartCoroutine(FadeIn());
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (timeblockMusic.CurrentlyPlaying.volume < MAX_VOLUME)
        {
            barMusic.volume -= VOLUME_UPDATE;
            timeblockMusic.CurrentlyPlaying.volume += VOLUME_UPDATE;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        while (barMusic.volume < MAX_VOLUME)
        {
            barMusic.volume += VOLUME_UPDATE;
            timeblockMusic.CurrentlyPlaying.volume -= VOLUME_UPDATE;
            yield return null;
        }
        barMusic.volume = MAX_VOLUME;
    }
}
