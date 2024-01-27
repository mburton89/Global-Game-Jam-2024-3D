using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollider : MonoBehaviour
{
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
        }
    }
}