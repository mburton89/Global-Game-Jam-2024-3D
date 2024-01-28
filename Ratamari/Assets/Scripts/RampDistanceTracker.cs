using TMPro;
using UnityEngine;

public class RampDistanceTracker : MonoBehaviour
{
    public Transform targetSpot;
    [HideInInspector] public float distanceTraveled;

    public TextMeshProUGUI distanceText;

    private bool shouldTrackDistance = true;


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

            distanceTraveled = Mathf.Max(0f, transform.position.z - targetSpot.position.z);

            int distanceTraveledInt = (int)distanceTraveled;

            if (distanceText != null)
            {
                distanceText.text = distanceTraveledInt + " Feet";
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