using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamAchievement : MonoBehaviour
{
    public static SteamAchievement script;
    private bool unlockTest = false;
    private void Awake()
    {
        script = this;
        if(!SteamManager.Initialized)
        {
            Debug.Log("No steam lmao bozo");
            return;
        }
    }
    public void UnlockSteamAchievement(string ID)
    {
        //if(TestSteamAchievement(ID) == false)
        //{
            SteamUserStats.SetAchievement(ID);
            SteamUserStats.StoreStats();
        //}
    }
    bool TestSteamAchievement(string ID)
    {
        return SteamUserStats.GetAchievement(ID, out unlockTest);
    }
    public void Debug_locksteamAchievement(string ID)
    {
        TestSteamAchievement(ID);
        SteamUserStats.ClearAchievement(ID);
    }
}
