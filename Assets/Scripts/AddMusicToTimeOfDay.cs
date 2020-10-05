using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMusicToTimeOfDay : TimeblockActionManager
{
    [SerializeField] private AudioSource morningMusic;
    [SerializeField] private AudioSource afternoonMusic;
    [SerializeField] private AudioSource eveningMusic;
    public AudioSource currentlyplaying;
    public bool musicFromRoom = false;
    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        switch (newTimeblock)
        {
            case TimeBlockType.NONE:

                break;
            case TimeBlockType.MORNING:
                BeginNewSound(morningMusic);
                currentlyplaying = morningMusic;
                break;
            case TimeBlockType.AFTERNOON:
                BeginNewSound(afternoonMusic);
                currentlyplaying = afternoonMusic;
                break;
            case TimeBlockType.EVENING:
                BeginNewSound(eveningMusic);
                currentlyplaying = eveningMusic;
                break;
            default:
                break;
        }

        if (musicFromRoom)
        {
            currentlyplaying.volume = 0;
        }
    }

    

    private void BeginNewSound(AudioSource current)
    {
        morningMusic.Stop();
        afternoonMusic.Stop();
        eveningMusic.Stop();
        current.Play();
    }
}
