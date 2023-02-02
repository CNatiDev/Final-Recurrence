using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Piano : MonoBehaviour
{
    public int pianoNum, noAchievement = 0;
    private int[] solution = new int[] { 1, 2, 1, 2, 1, 5, 3, 4 , 6 };
    private int[] input = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    public void PianoKUp(int i)
    {
        input[0] = input[1];
        input[1] = input[2];
        input[2] = input[3];
        input[3] = input[4];
        input[4] = input[5];
        input[5] = input[6];
        input[6] = input[7];
        input[7] = input[8];
        input[8] = i;
    }
    public void CheckPiano()
    {
        if (input[0] == solution[0] && input[1] == solution[1] && input[2] == solution[2] && input[3] == solution[3] &&
            input[4] == solution[4] && input[5] == solution[5] && input[6] == solution[6] && input[7] == solution[7] &&
            input[8] == solution[8] && noAchievement == 0)
        {
            SteamAchievement.script.UnlockSteamAchievement("NEW_ACHIEVEMENT_1_6");
            noAchievement = 1;
        }
    }
}
