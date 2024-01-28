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
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI bestText;

    int sizePoints;
    int speedPoints;
    int distancePoints;
    int totalPoints;

    public GameObject container;

    public Button retryButton;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        retryButton.onClick.AddListener(Retry);
    }

    public void Activate()
    {
        container.SetActive(true);

        if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Small)
        {
            sizePoints = 100;
        }
        else if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Medium)
        {
            sizePoints = 200;
        }
        else if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
        {
            sizePoints = 300;
        }
        else if (SizeManager.Instance.achievedMaxSize)
        {
            sizePoints = 400;
        }
        sizeText.SetText("Size: " + sizePoints);

        speedPoints = FindObjectOfType<SpeedDisplay>().highestSpeedThisSession;
        speedText.SetText("Speed: " + speedPoints);

        distancePoints = (int)FindObjectOfType<RampDistanceTracker>().distanceTraveled;
        distanceText.SetText("Distance: " + distancePoints);

        totalPoints = sizePoints + speedPoints + distancePoints;
        totalText.SetText("Total: " + totalPoints);

        if (totalPoints > PlayerPrefs.GetInt("Best"))
        {
            PlayerPrefs.SetInt("Best", totalPoints);
        }

        bestText.SetText("Best: " + PlayerPrefs.GetInt("Best"));
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
