using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Achievement
{
    public string id;
    public string title;
    public string description;
    public bool isUnlocked;
}

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public List<Achievement> achievements = new List<Achievement>();
    public GameObject achievementPopup;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public float popupDuration = 3f;

    [SerializeField] private GameObject achievementButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadAchievements(); // Load achievements from PlayerPrefs

        // Ensure the popup is initially inactive
        if (achievementPopup != null)
        {
            achievementPopup.SetActive(false);
        }

        if (achievementButton != null)
        {
            achievementButton.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        SaveAchievements();
    }

    private void OnApplicationPause(bool paused)    
    {
        if (paused)
        {
            SaveAchievements();
        }
    }

    // UnityEvent to trigger achievements
    public UnityEvent<string> OnAchievementUnlocked;

    // Method to unlock an achievement by ID
    public void UnlockAchievement(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;
            SaveAchievements(); // Save the updated achievement state
            ShowAchievementPopup(achievement); // Show the pop-up
            OnAchievementUnlocked?.Invoke(achievementId); // Trigger the UnityEvent
        }
    }

    public bool CheckIfAchievementUnlocked(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        if (achievement != null && achievement.isUnlocked)
        {
            return achievement.isUnlocked;
        }
        else
        {
            return false;
        }
    }

    // Method to show the achievement pop-up
    private void ShowAchievementPopup(Achievement achievement)
    {
        if (achievementPopup == null)
        {
            Debug.LogError("Achievement Popup GameObject is not assigned!");
            return;
        }

        if (titleText == null || descriptionText == null)
        {
            Debug.LogError("TitleText or DescriptionText components are not assigned!");
            return;
        }

        // Update the text
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;

        // Activate the popup
        achievementPopup.SetActive(true);

        // Start a coroutine to hide the popup after a delay
        StartCoroutine(HidePopupAfterDelay(popupDuration));
    }

    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        achievementPopup.SetActive(false);
    }

    // Save achievements to PlayerPrefs
    private void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.id, achievement.isUnlocked ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    // Load achievements from PlayerPrefs
    private void LoadAchievements()
    {
        foreach (var achievement in achievements)
        {
            achievement.isUnlocked = PlayerPrefs.GetInt(achievement.id, 0) == 1;
        }
    }

    // Reset all achievements (for testing or debugging)
    public void ResetAchievements()
    {
        foreach (var achievement in achievements)
        {
            achievement.isUnlocked = false;
        }
        SaveAchievements();
    }
}