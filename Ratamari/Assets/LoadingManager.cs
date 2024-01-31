using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public string sceneToLoad;

    public void Start()
    {
        //gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
