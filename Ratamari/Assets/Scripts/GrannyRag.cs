using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GrannyRag : MonoBehaviour
{
    public Animator GrannyIdle;
    private Rigidbody[] _ragdollRigidbodies;
    
    void Awake()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();

        transform.eulerAngles = new Vector3(0, 180, 0);
        //transform.position = new Vector3(transform.position.x, transform.position.y ,  transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableRagdoll();
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter");
        EnableRagdoll(collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
        GrannyIdle.gameObject.GetComponent<Animator>().enabled = false;
/*        GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        { 
           
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Granny OnTriggerEnter");
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies) 
        {
            rigidbody.isKinematic = true;
        }

    }

    public void EnableRagdoll()
    {
        if (GetComponent<NPCMove>())
        {
            GetComponent<NPCMove>().enabled = false;
        }

        GetComponent<Collider>().enabled = false;

        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(Vector3.forward * 800);
        }
    }

    public void EnableRagdoll(float initialVelocity)
    {
        if (GetComponent<NPCMove>())
        {
            GetComponent<NPCMove>().enabled = false;
        }

        GetComponent<Collider>().enabled = false;

        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(Vector3.forward * 400 * initialVelocity);
        }
    }

    public void DisableColliders()
    {
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.isTrigger = true;
        }

        //print("DisableColliders");

        //Destroy(GetComponent<Rigidbody>());

        //foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        //{
        //    Destroy(rb);
        //}
    }
}
