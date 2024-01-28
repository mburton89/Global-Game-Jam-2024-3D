using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollider : MonoBehaviour
{
    GameObject ball;
    public float propValue;
    public bool pickedUp;

    Collider col;

    public bool isRat;
    public enum Size
    { 
        Small,
        Medium,
        Large,
    }

    public Size size;

    private void Start()
    {
        col = GetComponent<Collider>();

        ball = FindObjectOfType<BallMovement>().gameObject;
        if (size == Size.Small)
        {
            propValue = 0.01f;
        }
        if (size == Size.Medium)
        {
            propValue = 0.02f;
        }
        if (size == Size.Large)
        {
            propValue = 0.03f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (size == Size.Small)
        {
            col.isTrigger = true;
        }
        else if (size == Size.Medium)
        {
            if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Medium || SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
            {
                col.isTrigger = true;
            }
            else 
            { 
                col.isTrigger = false; 
            }
        }
        else if (size == Size.Large)
        {
            if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
            {
                col.isTrigger = true;
            }
            else
            {
                col.isTrigger = false;
            }
        }
    }
}