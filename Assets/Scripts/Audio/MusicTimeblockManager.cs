using UnityEngine;

public class MusicTimeblockManager : TimeblockActionManager
{
    [SerializeField]
    private AudioSource currentlyPlaying;
    
    [SerializeField] 
    private AudioClip morningMusic, afternoonMusic, eveningMusic;

    public AudioSource CurrentlyPlaying => currentlyPlaying;

    protected override void HandleTimeblockChange(TimeBlockType newTimeblock)
    {
        switch (newTimeblock)
        {
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

    private void BeginNewSound(AudioClip current)
    {
        currentlyPlaying.clip = current;
        currentlyPlaying.Play();
    }
}