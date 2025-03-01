using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;


public class PortraitSwitcher : MonoBehaviour
{
    public Image ratPortrait;

    public int speedIndicator;

    [SerializeField] private int lowSpeedlevel;
    [SerializeField] private int medSpeedlevel;
    [SerializeField] private int highSpeedlevel;

    public Rigidbody rb;

    public Sprite slowSpeedPortrait;
    public Sprite mediumSpeedPortrait;
    public Sprite fastSpeedPortrait;

    

    // Update is called once per frame
    void Update()
    {
        //int speed = speedDisplay.speed;
        speedIndicator = Mathf.RoundToInt(rb.velocity.magnitude);

        Debug.Log("The current speed is: " + speedIndicator);

        if (speedIndicator <= lowSpeedlevel)
        {
            ratPortrait.sprite = slowSpeedPortrait;
            Debug.Log("I should be slow portrait");
        }
        else if (speedIndicator >= lowSpeedlevel && speedIndicator <= highSpeedlevel)
        {
            ratPortrait.sprite = mediumSpeedPortrait;
            Debug.Log("I should be medium portrait");
        }
        else if (speedIndicator >= highSpeedlevel)
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
