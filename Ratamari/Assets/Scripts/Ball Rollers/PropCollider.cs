using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollider : MonoBehaviour
{
    GameObject ball;
    public float propSize;

    private void Start()
    {
        ball = FindObjectOfType<BallMovement>().gameObject;
        propSize = transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball && ball.GetComponent<BallMovement>().currentBallSize >= propSize)
        {
            GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }
}