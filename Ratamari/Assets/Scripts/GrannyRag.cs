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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableRagdoll();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnableRagdoll();
        GrannyIdle.gameObject.GetComponent<Animator>().enabled = false;
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies) 
        {
            rigidbody.isKinematic = true;
        }

    }

    private void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
