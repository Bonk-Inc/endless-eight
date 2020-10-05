using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMusicToTimeOfDay : TimeblockActionManager
{
    [SerializeField] private AudioSource morningMusic;
    [SerializeField] private AudioSource afternoonMusic;
    [SerializeField] private AudioSource eveningMusic;
    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        switch (newTimeblock)
        {
            case TimeBlockType.NONE:
                
                break;
            case TimeBlockType.MORNING:
                BeginNewSound(morningMusic);
                break;
            case TimeBlockType.AFTERNOON:
                BeginNewSound(afternoonMusic);
                break;
            case TimeBlockType.EVENING:
                BeginNewSound(eveningMusic);
                break;
            default:
                break;
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
