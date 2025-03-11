using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    public static EndGameMenu Instance;

    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI roadBlocksText;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI bestText;

    int sizePoints;
    public int  speedPoints;
    int distancePoints;
    [HideInInspector] public int roadBlocksPoints;
    int totalPoints;

    public GameObject container;

    public Button retryButton;

    public GameObject languageMenuContainer;
    public Button languageButton;

    public GameObject achievementButton;

    public Image endGameImage;

    public Sprite badEnding;
    public Sprite badTokyoEnding;
    public Sprite medEnding;
    public Sprite goodSanFranEnding;
    public Sprite goodTokyoEnding;

    private const int DISTANCE_ACH_1 = 150;
    private const int DISTANCE_ACH_2 = 300;
    private const int DISTANCE_ACH_3 = 500;

    bool hasActivated;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        languageButton.onClick.AddListener(OpenLanguageMenu);
    }

    public void Activate()
    {
        if (hasActivated) return;

        hasActivated = true;

        container.SetActive(true);
        //container.transform.localScale = Vector3.one;
        retryButton.gameObject.SetActive(false);
        StartCoroutine(DelayShowRetry());

        if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Small)
        {
            sizePoints = 100;
        }
        else if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Medium)
        {
            sizePoints = 200;
        }
        else if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large && !SizeManager.Instance.achievedMaxSize)
        {
            sizePoints = 300;
        }
        else if (SizeManager.Instance.achievedMaxSize)
        {
            sizePoints = 400;
        }
        sizeText.SetText("" + sizePoints);

        speedPoints = FindObjectOfType<SpeedDisplay>().highestSpeedThisSession;
        speedText.SetText("" + speedPoints);

        distancePoints = (int)FindObjectOfType<RampDistanceTracker>().distanceTraveled;
        distanceText.SetText("" + distancePoints);

        roadBlocksText.SetText("" + roadBlocksPoints);

        totalPoints = sizePoints + speedPoints + distancePoints + roadBlocksPoints;
        totalText.SetText("" + totalPoints);

        if (totalPoints > PlayerPrefs.GetInt("Best"))
        {
            PlayerPrefs.SetInt("Best", totalPoints);
        }

        bestText.SetText("" + PlayerPrefs.GetInt("Best"));

        DetermineEndScreen((float)distancePoints);
    }

    void Retry()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    private IEnumerator DelayShowRetry()
    {
        yield return new WaitForSeconds(2f);
        retryButton.gameObject.SetActive(true);
        retryButton.onClick.AddListener(Retry);
    }

    void OpenLanguageMenu()
    { 
        languageMenuContainer.SetActive(true);
    }

    void ShowAchievementButton()
    {
        achievementButton.SetActive(true);
    }

    public void DetermineEndScreen(float distance)
    {
        ShowAchievementButton();

        if (distance >= DISTANCE_ACH_1)
        {
            UnlockDistanceAchievement1();
        }

        if (distance >= DISTANCE_ACH_2 && AchievementManager.Instance.CheckIfAchievementUnlocked("001"))
        {
            UnlockDistanceAchievement2();
        }

        if (distance >= DISTANCE_ACH_3 && AchievementManager.Instance.CheckIfAchievementUnlocked("002"))
        {
            UnlockDistanceAchievement3();
        }

        if (distance <= 300)
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                endGameImage.sprite = badTokyoEnding;
            }
            else
            {
                endGameImage.sprite = badEnding;
                
            }

            
        }
        else if (distance > 300 && distance <= 650)
        {
            endGameImage.sprite = medEnding;
        }
        else 
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                endGameImage.sprite = goodTokyoEnding;
            }
            else
            {
                endGameImage.sprite = goodSanFranEnding;
            }
        }
    }

    private void UnlockDistanceAchievement1()
    {
        AchievementManager.Instance.UnlockAchievement("001");
    }

    private void UnlockDistanceAchievement2()
    {
        AchievementManager.Instance.UnlockAchievement("002");
    }

    private void UnlockDistanceAchievement3()
    {
        AchievementManager.Instance.UnlockAchievement("003");
    }
}
