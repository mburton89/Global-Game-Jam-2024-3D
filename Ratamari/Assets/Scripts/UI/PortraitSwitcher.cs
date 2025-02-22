using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;


public class PortraitSwitcher : MonoBehaviour
{
    public Image ratPortrait;

    public Sprite slowSpeedPortrait;
    public Sprite mediumSpeedPortrait;
    public Sprite fastSpeedPortrait;


    // Update is called once per frame
    void Update()
    {
        if (SizeIndicator.Instance.level1Fill == true)
        {
            ratPortrait.sprite = slowSpeedPortrait;
            Debug.Log("I should be slow portrait");
        }
        else if (SizeIndicator.Instance.level2Fill == true)
        {
            ratPortrait.sprite = mediumSpeedPortrait;
            Debug.Log("I should be medium portrait");
        }
        else if (SizeIndicator.Instance.level3Fill == true)
        {
            ratPortrait.sprite = fastSpeedPortrait;
            Debug.Log("I should be fast portrait");
        }
        else
        {
            throw new System.Exception("Portrait Switch is now working");
        }
    }
}
