using TMPro;
using UnityEngine;

public class RampDistanceTracker : MonoBehaviour
{
    public Transform targetSpot;
    [HideInInspector] public float distanceTraveled;

    public TextMeshProUGUI distanceText;

    private bool shouldTrackDistance;


    void Update()
    {
        if (distanceTraveled < 1)
        {
            distanceText.transform.transform.localScale = Vector3.zero;
        }
        else
        {
            distanceText.transform.transform.localScale = Vector3.one;
        }

        if (shouldTrackDistance)
        {
            GetComponent<BallMovement>().jumpingOffRamp = true;
            distanceTraveled = Mathf.Max(0f, transform.position.z - targetSpot.position.z);

            int distanceTraveledInt = (int)distanceTraveled;

            if (distanceText != null)
            {
                distanceText.text = distanceTraveledInt + " Feet";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ramp"))
        {
            shouldTrackDistance = true;
        }
    }
}