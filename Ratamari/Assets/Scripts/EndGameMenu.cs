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
    int speedPoints;
    int distancePoints;
    [HideInInspector] public int roadBlocksPoints;
    int totalPoints;

    public GameObject container;

    public Button retryButton;

    public GameObject languageMenuContainer;
    public Button languageButton;
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
}
