using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInBar : MonoBehaviour
{
    [SerializeField] GameObject musicBox;
    private AudioSource music;
    [SerializeField] private AddMusicToTimeOfDay stopMusic;
    private const float MAX_VOLUME = 0.2f;
    private Coroutine currentCorotine;
    private void Start()
    {
        music = musicBox.GetComponent<AudioSource>();

    }



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
            music.volume -= 0.0012f;
            stopMusic.currentlyplaying.volume += 0.0012f;
            if (stopMusic.currentlyplaying.volume >= MAX_VOLUME)
            {
               
                music.Stop();
                
                break;
            }
            yield return null;
        }


    }

    IEnumerator FadeIn()
    {
        music.Play();
        while (true)
        {
            music.volume += 0.0012f;
            stopMusic.currentlyplaying.volume -= 0.0012f;
            if (music.volume >= MAX_VOLUME)
            {
                music.volume = MAX_VOLUME;
                break;

            }
            yield return null;
        }

    }


}
