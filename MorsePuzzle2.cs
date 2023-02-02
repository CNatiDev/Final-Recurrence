using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MorsePuzzle2 : MonoBehaviour
{
    public static MorsePuzzle2 instance;
    public UnityEvent allCorrect, allWrong, pulledLeverEvent1, pulledLeverEvent2, pulledLeverEvent3, pulledLeverEvent4, pulledLeverEvent5;
    private int[] solution = new int[] { 4, 2, 3, 1, 5 };
    public int[] input = new int[] { -1, -1, -1, -1, -1 };
    int leversPulled = 0;
    public bool canPull1 = true, canPull2 = true, canPull3 = true, canPull4 = true, canPull5 = true, allCorrectLevers = false;
    private void Awake()
    {
        instance = this;
    }
    public void PullLever(int leverNumber)
    {
        switch (leverNumber)
        {
            case 1:
                if (canPull1)
                {
                    leversPulled++;
                    input[0] = input[1];
                    input[1] = input[2];
                    input[2] = input[3];
                    input[3] = input[4];
                    input[4] = leverNumber;
                    pulledLeverEvent1.Invoke();
                    canPull1 = false;
                    break;
                }
                break;
            case 2:
                if (canPull2)
                {
                    leversPulled++;
                    input[0] = input[1];
                    input[1] = input[2];
                    input[2] = input[3];
                    input[3] = input[4];
                    input[4] = leverNumber;
                    pulledLeverEvent2.Invoke();
                    canPull2 = false;
                    break;
                }
                break;
            case 3:
                if (canPull3)
                {
                    leversPulled++;
                    input[0] = input[1];
                    input[1] = input[2];
                    input[2] = input[3];
                    input[3] = input[4];
                    input[4] = leverNumber;
                    pulledLeverEvent3.Invoke();
                    canPull3 = false;
                    break;
                }
                break;
            case 4:
                if (canPull4)
                {
                    leversPulled++;
                    input[0] = input[1];
                    input[1] = input[2];
                    input[2] = input[3];
                    input[3] = input[4];
                    input[4] = leverNumber;
                    pulledLeverEvent4.Invoke();
                    canPull4 = false;
                    break;
                }
                break;
            case 5:
                if (canPull5)
                {
                    leversPulled++;
                    input[0] = input[1];
                    input[1] = input[2];
                    input[2] = input[3];
                    input[3] = input[4];
                    input[4] = leverNumber;
                    pulledLeverEvent5.Invoke();
                    canPull5 = false;
                    break;
                }
                break;
        }
    }
    public void checkCorrect()
    {
        if(leversPulled == 5 && input[0] == solution[0] && input[1] == solution[1] && input[2] == solution[2] && input[3] == solution[3] && input[4] == solution[4])
        {
            allCorrect.Invoke();
        }
        else
        {
            allWrong.Invoke();
            leversPulled = 0;
            input = new int[] { -1, -1, -1, -1, -1 };
            canPull1 = canPull2 = canPull3 = canPull4 = canPull5 = true;
        }
    }
}
