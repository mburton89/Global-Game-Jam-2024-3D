using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputTestMenu : MonoBehaviour
{
    public Button tilt;
    public Button swipe;
    // Start is called before the first frame update
    void Start()
    {
        tilt.onClick.AddListener(LoadTilt);
        swipe.onClick.AddListener(LoadSwipe);
    }

    void LoadTilt()
    {
        SceneManager.LoadScene(1);
    }

    void LoadSwipe()
    {
        SceneManager.LoadScene(2);
    }
}
