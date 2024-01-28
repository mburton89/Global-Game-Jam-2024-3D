using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollider : MonoBehaviour
{
    GameObject ball;
    public float propSize;
    public int propSizeTier;
    public bool pickedUp;

    Collider collider;

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
        collider = GetComponent<Collider>();

        ball = FindObjectOfType<BallMovement>().gameObject;
        if (transform.localScale.magnitude >= 0.5f && transform.localScale.magnitude < 1.24f)
        {
            propSizeTier = 1;
            propSize = 0.0125f;
        }
        if (transform.localScale.magnitude >= 1.25f && transform.localScale.magnitude < 1.99f)
        {
            propSizeTier = 2;
            propSize = 0.025f;
        }
        if (transform.localScale.magnitude >= 2f && transform.localScale.magnitude < 2.75f)
        {
            propSizeTier = 3;
            propSize = 0.0375f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (size == Size.Small)
        {
            collider.isTrigger = true;
        }
        else if (size == Size.Medium)
        {
            if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Medium || SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
            {
                collider.isTrigger = true;
            }
            else 
            { 
                collider.isTrigger = false; 
            }
        }
        else if (size == Size.Large)
        {
            if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
            {
                collider.isTrigger = true;
            }
            else
            {
                collider.isTrigger = false;
            }
        }
    }
}