using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public Transform targetSpot;
    private float distanceTraveled;

    public TextMeshProUGUI distanceText;

    private bool shouldTrackDistance = true;

    void Update()
    {
        if (shouldTrackDistance)
        {
            distanceTraveled = Mathf.Max(0f, transform.position.z - targetSpot.position.z);

            if (distanceText != null)
            {
                distanceText.text = "Distance Traveled: " + distanceTraveled.ToString("F2") + " meters";
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Target"))
        {
            shouldTrackDistance = false;
        }
    }
}
