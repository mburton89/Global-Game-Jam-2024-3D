using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager Instance;

    [HideInInspector]
    public string DISTANCE_200 = "distance_200";
    [HideInInspector]
    public string DISTANCE_300 = "distance_300";
    [HideInInspector]
    public string DISTANCE_400 = "distance_400"; 

    private void Start()
    {
        Instance = this;

        Debug.Log(DISTANCE_200 + " " + PlayerPrefs.GetInt(DISTANCE_200));
        Debug.Log(DISTANCE_300 + " " + PlayerPrefs.GetInt(DISTANCE_300));
        Debug.Log(DISTANCE_400 + " " + PlayerPrefs.GetInt(DISTANCE_400));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            Debug.LogWarning("Player Prefs Deleted!");
        }
    }

    public void UnlockAchievement(string achievementID)
    {
        PlayerPrefs.SetInt(achievementID, 1);
    }
}
