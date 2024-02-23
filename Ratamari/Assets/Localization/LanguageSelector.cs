using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    bool isActive = false;

    private void Start()
    {
        int savedLocaleID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLangauge(savedLocaleID);
    }
    public void ChangeLangauge(int localeID)
    {
        if (isActive) return;

        StartCoroutine(SetLanguage(localeID));
    }
    IEnumerator SetLanguage(int localeID)
    {
        isActive = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleKey", localeID);
        isActive = false;
    }
}
