using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollider : MonoBehaviour
{
    public float sizetoAdd = 0.1f;
    private Transform ballTransform;
    private SphereCollider ballCollider;
    private float currentBallScaleX;
    private float currentBallScaleY;
    private float currentBallScaleZ;
    private float currentBallRadius;

    private void Start()
    {
        ballTransform = GetComponent<Transform>();
        ballCollider = GetComponent<SphereCollider>();
        currentBallScaleX = ballTransform.localScale.x;
        currentBallScaleY = ballTransform.localScale.y;
        currentBallScaleZ = ballTransform.localScale.z;
        currentBallRadius = ballCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ratball")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Ratball")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            GetComponent<BoxCollider>().enabled = false;

            other.GetComponent<SphereCollider>().radius += 0.01f;
        }
    }
}