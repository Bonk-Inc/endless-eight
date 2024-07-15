using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInBar : MonoBehaviour
{
    [SerializeField] 
    private AudioSource musicBox;
    
    [SerializeField] 
    private AddMusicToTimeOfDay stopMusic;

    [SerializeField]
    private float updateMusic = 0.0012f;

    private const float MAX_VOLUME = 0.2f;
    private Coroutine currentCorotine;

    private void OnTriggerEnter(Collider other)
    {
        if (currentCorotine != null) StopCoroutine(currentCorotine);
        
        if (other.gameObject.name.Equals("Player")) stopMusic.musicFromRoom = true;
        currentCorotine = StartCoroutine(FadeIn());
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentCorotine != null) StopCoroutine(currentCorotine);
        if(other.gameObject.name.Equals("Player")) stopMusic.musicFromRoom = false;
        currentCorotine = StartCoroutine(FadeOut());

    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            musicBox.volume -= updateMusic;
            stopMusic.currentlyplaying.volume += updateMusic;
            if (stopMusic.currentlyplaying.volume >= MAX_VOLUME)
            {
                musicBox.volume = 0f;
                //musicBox.Stop();
                stopMusic.currentlyplaying.volume = MAX_VOLUME;


                break;
            }
            yield return null;
        }


    }

    IEnumerator FadeIn()
    {
        //musicBox.Play();
        while (true)
        {
            musicBox.volume += updateMusic;
            stopMusic.currentlyplaying.volume -= updateMusic;
            if (musicBox.volume >= MAX_VOLUME)
            {
                stopMusic.currentlyplaying.volume = 0;
                musicBox.volume = MAX_VOLUME;
                break;

            }
            yield return null;
        }

    }


}
