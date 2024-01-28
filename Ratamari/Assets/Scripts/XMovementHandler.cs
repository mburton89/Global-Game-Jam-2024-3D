using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMovementHandler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -5f;
    public float maxX = 5f;

    void Update()
    {
        // Get input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate new position based on input
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Clamp the new position to stay within the min and max X values
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply the new position to the object
        transform.position = newPosition;
    }
}
