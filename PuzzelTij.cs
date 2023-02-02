using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PuzzelTij : MonoBehaviour
{   //Variables
    public bool[] TijStatus;
    public UnityEvent @event;
    //We use the function to validate the completion of an important step in the puzzle
    public void SetActiveTij(int i)
    {
        TijStatus[i] = true;
    }
    //We use the function to invalidate the completion of an important step in the puzzle
    public void SetActiveFalseTij(int i)
    {
        TijStatus[i] = false;
    }
    //We use the function to check if all the steps were successful
    public void FinalCheck()
    {
        int ok = 1;
        for (int i = 0; i < TijStatus.Length; i++)
        {

            if (TijStatus[i] == false)
            {
                ok = 0;
            }

        }
        if (ok == 1)
        {
            @event.Invoke();
        }

    }
    private void Update()
    {
        FinalCheck();


    }

}
