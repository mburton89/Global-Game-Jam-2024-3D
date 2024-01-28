using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshProUGUI speedText;

    void Update()
    {
        // Calculate the speed magnitude and convert it to one decimal place
        //float speed = Mathf.Round(rb.velocity.magnitude * 10f) / 10f;

        int speed = Mathf.RoundToInt(rb.velocity.magnitude);

        // Display the speed in the UI text
        speedText.text =  speed.ToString() + " MPH";

    }
}