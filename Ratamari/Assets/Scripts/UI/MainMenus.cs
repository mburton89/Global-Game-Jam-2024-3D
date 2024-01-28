using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public void switchToMainMenu()
    {
        //PlayButtonSound();

        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void switchToSettingsMenu()
    {
        //PlayButtonSound();

        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    // void PlayButtonSound()
    //{
    //  SoundManager.Instance.Play("ButtonSelect");
    //}
}
