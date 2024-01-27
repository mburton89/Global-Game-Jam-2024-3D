using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    public Camera cam;

    public float maxMoveSpeed;
    public float initialSpeed; // how much speed the ball has when launching off the hill
    public float jumpForce;
    public float currentZVelocity;
    float lastZVelocity;
    public float currentBallSize;
    float initialBallRadius;

    public int maxJumps;
    public int currentJumps;
    public LayerMask groundLayer;

    public bool isGrounded;
    public bool movedForward;

    float moveInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialBallRadius = GetComponent<SphereCollider>().radius;
        currentBallSize = 1;
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

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed) + (moveInput / 1.5f), rb.velocity.y, rb.velocity.z);
        currentZVelocity = rb.velocity.z;
        lastZVelocity = rb.velocity.z;
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

        if (rb.velocity.y <= 0)
        {
            CheckIfGrounded();
        }
    }

    public void CheckIfGrounded()
    {
        // draw an imaginary line from the player (ball) center downwards. if the line touches an object on the ground layer, consider ourselves grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (GetComponent<SphereCollider>().radius * 2) + 0.05f);
        ResetJumps();
    }

    public void ResetJumps()
    {
        if (isGrounded && currentJumps != maxJumps)
        {
            currentJumps = maxJumps;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // pick up props to get bigger
        if (other.gameObject.CompareTag("Prop") && other.transform.localScale.magnitude <= currentBallSize)
        {
            other.transform.parent = transform;
            currentBallSize += 0.01f;
            rb.GetComponent<SphereCollider>().radius += 0.01f;

            cam.GetComponent<CameraFollow>().followPositionOffset.y += 0.01f;
            cam.GetComponent<CameraFollow>().followPositionOffset.z -= 0.01f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // crash into too-big stuff to get smaller
        if (collision.gameObject.CompareTag("Prop") && collision.transform.localScale.magnitude > currentBallSize)
        {
            if (lastZVelocity >= 10)
            {
                print("Crashed into larger prop! Removed " + lastZVelocity / 100 + " from its size!");

                currentBallSize -= (lastZVelocity / 100);
                rb.GetComponent<SphereCollider>().radius -= (lastZVelocity / 100);

                cam.GetComponent<CameraFollow>().followPositionOffset.y -= 0.01f;
                cam.GetComponent<CameraFollow>().followPositionOffset.z += 0.01f;

                // prevent ball from getting toooo small
                if (currentBallSize < initialBallRadius * 2)
                {
                    currentBallSize = initialBallRadius * 2;
                    rb.GetComponent<SphereCollider>().radius = initialBallRadius;

                    cam.GetComponent<CameraFollow>().followPositionOffset.y = 3;
                    cam.GetComponent<CameraFollow>().followPositionOffset.z = -6;

                    print("Ball size was limited to what it started at!");
                }
            }
        }
    }

    // debug function: draws line from ball's center downwards, visualizes ground check
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new(transform.position.x, transform.position.y - (GetComponent<SphereCollider>().radius * 2) - 0.05f, transform.position.z));
    }
}
