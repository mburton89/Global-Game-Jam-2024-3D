using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorJump : MonoBehaviour
{
    public float jumpForce = 5f; 
    public float jumpInterval = 3f; 

    private Rigidbody rigidbody;
    private float nextJumpTime;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        nextJumpTime = Time.time + jumpInterval;
    }

    void Update()
    {
        if (Time.time >= nextJumpTime)
        {
            Jump();
            nextJumpTime = Time.time + jumpInterval;
        }
    }

    void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
