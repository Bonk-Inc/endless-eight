using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManagement : MonoBehaviour
{
    private int loopNumber;
    public void GoToNextLoop()
    {
        AddLoopIteration(1);
    }

    public void AddLoopIteration(int amount)
    {
        loopNumber += amount;
        ChangePositionsPeople();
        if (loopNumber >= 10)
        {
            EndGame();
        }
    }

    private void ChangePositionsPeople()
    {
        //TODO change positions
    }

    private void EndGame()
    {
        //TODO end game
    }

}
