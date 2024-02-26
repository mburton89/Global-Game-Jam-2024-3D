using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayCloseMenu : MonoBehaviour
{
    Button button;
    public GameObject container;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CloseMenu);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(CloseMenu);
    }

    void CloseMenu()
    {
        StartCoroutine(DelayClose());
    }

    private IEnumerator DelayClose()
    {
        yield return new WaitForSeconds(.1f);
        container.SetActive(false);
    }
}
