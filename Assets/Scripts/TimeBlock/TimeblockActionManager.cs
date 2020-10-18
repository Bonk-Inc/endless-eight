using UnityEngine;

public abstract class TimeblockActionManager : MonoBehaviour
{
    [SerializeField]
    private TimeBlockmanager timeBlockmanager;

    private void Start()
    {
        timeBlockmanager.OnTimeblockChange += (sender, args) => HandleTimeblockChange(args.timeBlock);
        HandleTimeblockChange(timeBlockmanager.CurrentTimeblock);
    }

    protected abstract void HandleTimeblockChange(TimeBlockType newTimeblock);

    private void Reset()
    {
        timeBlockmanager = FindObjectOfType<TimeBlockmanager>();
    }
}