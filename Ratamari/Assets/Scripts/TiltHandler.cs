using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TiltHandler : MonoBehaviour
{
    public float tiltSpeed = 5f; // Adjust this value to control the sensitivity of the tilt

    private Rigidbody rb;

    public float jumpForce = 5f;

    bool canJump = true;

    public TextMeshProUGUI tiltTextX;
    public TextMeshProUGUI tiltTextY;
    public TextMeshProUGUI tiltTextZ;

    public TextMeshProUGUI rotationRateUnbiased;

    public TextMeshProUGUI accelerationTextX;
    public TextMeshProUGUI accelerationTextY;
    public TextMeshProUGUI accelerationTextZ;

    public float maxXVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Enable gyroscope
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Get the tilt angle around the x-axis (pitch)
        float tiltAngle = Input.gyro.attitude.eulerAngles.x;

        tiltTextX.SetText("Tilt Angle X: " + Input.gyro.attitude.eulerAngles.x);
        tiltTextY.SetText("Tilt Angle Y: " + Input.gyro.attitude.eulerAngles.y);
        tiltTextZ.SetText("Tilt Angle Z: " + Input.gyro.attitude.eulerAngles.z);

        rotationRateUnbiased.SetText("Input.gyro.rotationRateUnbiased: " + Input.gyro.rotationRateUnbiased);

        accelerationTextX.SetText("Acceleration Angle X: " + Input.acceleration.x);
        accelerationTextY.SetText("Acceleration Angle Y: " + Input.acceleration.y);
        accelerationTextZ.SetText("Acceleration Angle Z: " + Input.acceleration.z);

        // Adjust velocity based on tilt
        float xVelocity = Input.acceleration.x * tiltSpeed;

        if (xVelocity > maxXVelocity)
        { 
            xVelocity = maxXVelocity;
        }
        else if (xVelocity < -maxXVelocity)
        {
            xVelocity = -maxXVelocity;
        }

        // Apply the velocity to the Rigidbody
        rb.velocity = new Vector3(xVelocity, rb.velocity.y, rb.velocity.z);

        if (Input.GetMouseButtonDown(0) && canJump)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false;
    }
}
