using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float maxMoveSpeed;
    public float initialSpeed; // how much speed the ball has when launching off the hill
    public float jumpForce;

    public int maxJumps;
    public int currentJumps;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool isGrounded;
    public bool movedForward;

    float moveInput;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * initialSpeed, ForceMode.Impulse);
        }

        Jump();

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed) + (moveInput / 25), rb.velocity.y, rb.velocity.z);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumps > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                currentJumps--;
            }
        }
        CheckIfGrounded();
    }

    public void CheckIfGrounded()
    {
        // draw an imaginary line from the player (ball) center downwards. if the line touches an object on the ground layer, consider ourselves grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<SphereCollider>().radius + 0.5f);
        ResetJumps();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down);
    }

    public void ResetJumps()
    {
        if (isGrounded && currentJumps != maxJumps)
        {
            print("wa");
            currentJumps = maxJumps;
        }
    }
}
