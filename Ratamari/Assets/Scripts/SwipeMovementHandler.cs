using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovementHandler : MonoBehaviour
{
    public float dragSensitivity = 0.1f; // Adjust this value to control the sensitivity of the drag
    public float maxVelocityX = 5f; // Adjust this value to set the maximum X-axis velocity
    public float jumpForce = 5f; // Adjust this value to control the jump force
    public float groundPoundForce = 10f; // Adjust this value to control the ground pound force

    private Rigidbody rb;
    private bool isDragging = false;
    private Vector2 touchStartPos;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = true;
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector2 delta = touch.position - touchStartPos;
                        float forceX = delta.x * dragSensitivity;

                        // Add force to the Rigidbody on the X-axis
                        rb.AddForce(Vector3.right * forceX, ForceMode.VelocityChange);

                        // Limit the X-axis velocity
                        float clampedVelocityX = Mathf.Clamp(rb.velocity.x, -maxVelocityX, maxVelocityX);
                        rb.velocity = new Vector3(clampedVelocityX, rb.velocity.y, rb.velocity.z);
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;

                    // Check swipe direction for jump or ground pound
                    Vector2 swipeDelta = touch.position - touchStartPos;

                    if (swipeDelta.y > .4f && canJump)
                    {
                        // Swipe up for jump
                        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                        canJump = false; // Prevent double jumping
                    }
                    else if (swipeDelta.y < .4f)
                    {
                        // Swipe down for ground pound if the object is on the ground
                        rb.AddForce(Vector3.down * groundPoundForce, ForceMode.VelocityChange);
                    }
                    break;
            }
        }
    }
}