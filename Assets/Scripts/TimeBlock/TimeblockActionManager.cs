using UnityEngine;

public abstract class TimeblockActionManager : MonoBehaviour
{
    [SerializeField]
    private TimeBlockManager timeBlockManager;

    private void Start()
    {
        timeBlockManager.OnTimeblockChange += (sender, args) => HandleTimeblockChange(args.timeBlock);
        HandleTimeblockChange(timeBlockManager.CurrentTimeblock);
    }

    protected abstract void HandleTimeblockChange(TimeBlockType newTimeblock);

    private void Reset()
    {
        timeBlockManager = FindObjectOfType<TimeBlockManager>();
    }
}