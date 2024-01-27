using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;  // Reference to the target object
    public float smoothSpeed = 0.5f;  // Smoothing factor for camera movement
    public Vector3 offset = new Vector3(0f, 2f, -5f);  // Offset from the target in world space

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned. Please assign a target in the inspector.");
            return;
        }

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
        // Use SmoothDamp to smoothly interpolate between current position and desired position
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}