using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using TMPro;

public class AchievementDisplay : MonoBehaviour
{
    [Header("Achievement Settings")]
    public string achievementId;
    public string lockedAchievementId;

    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        UpdateAchievementDisplay();
    }

    public void UpdateAchievementDisplay()
    {
        if (AchievementManager.Instance == null)
        {
            Debug.LogError("AchievementManager instance not found!");
            return;
        }

        // Check if the achievement is unlocked
        bool isUnlocked = AchievementManager.Instance.CheckIfAchievementUnlocked(achievementId);

        // Determine which achievement ID to use
        string displayId = isUnlocked ? achievementId : lockedAchievementId;

        // Get the achievement data from the AchievementManager
        Achievement achievement = AchievementManager.Instance.achievements.Find(a => a.id == displayId);

        if (achievement != null)
        {
            // Update the title and description text
            if (titleText != null)
            {
                titleText.text = achievement.title;
            }
            else
            {
                Debug.LogWarning("TitleText reference is not assigned!");
            }

            if (descriptionText != null)
            {
                descriptionText.text = achievement.description;
            }
            else
            {
                Debug.LogWarning("DescriptionText reference is not assigned!");
            }
        }
        else
        {
            Debug.LogWarning($"Achievement with ID '{achievementId}' not found!");
        }
    }
}
