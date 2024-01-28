using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public Animator transition;

    public string sceneToLoad;

    public float transitionTime = 1f;

    public void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
