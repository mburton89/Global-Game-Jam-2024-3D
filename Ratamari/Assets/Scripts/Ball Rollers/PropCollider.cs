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

    private void Start()
    {
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
        if (ball && ball.GetComponent<BallMovement>().currentBallSize >= transform.localScale.magnitude)
        {
            GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }
}