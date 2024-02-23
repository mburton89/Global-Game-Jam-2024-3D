using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using TMPro;
public class ScoreTest : MonoBehaviour
{
    [SerializeField] LocalizedString localeStringScore;
    [SerializeField] TextMeshProUGUI textComp;

    int score;

    private void OnEnable()
    {
        localeStringScore.Arguments = new object[] { score };
        localeStringScore.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        localeStringScore.StringChanged -= UpdateText;
    }

    void UpdateText(string value)
    { 
        textComp.text = value;
    }

    public void IncreaseScore()
    {
        score++;
        localeStringScore.Arguments[0] = score;
        localeStringScore.RefreshString();
    }
}
