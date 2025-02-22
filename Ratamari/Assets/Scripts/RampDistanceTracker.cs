using TMPro;
using UnityEngine;

public class RampDistanceTracker : MonoBehaviour
{
    public Transform targetSpot;
    [HideInInspector] public float distanceTraveled;

    public TextMeshProUGUI distanceText;
    public Transform label;

    private bool shouldTrackDistance = true;

    int distanceTraveledInt;

    void Update()
    {
        print("shouldTrackDistance: " + shouldTrackDistance);

        if (distanceTraveled < 1)
        {
            distanceText.transform.transform.localScale = Vector3.zero;
            label.localScale = Vector3.zero;
        }
        else
        {
            distanceText.transform.transform.localScale = Vector3.one;
            label.localScale = Vector3.one;
        }

        if (shouldTrackDistance)
        {

            distanceTraveled = Mathf.Max(0f, transform.position.z - targetSpot.position.z);

            distanceTraveledInt = (int)distanceTraveled;

            if (distanceText != null)
            {
                distanceText.text = distanceTraveledInt.ToString();
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