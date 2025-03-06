using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshProUGUI speedText;
    public int speed;

    public int slowSpeed = 20;
    public int fastSpeed = 45;

    [HideInInspector] public int highestSpeedThisSession;

    public void Update()
    {
        // Calculate the speed magnitude and convert it to one decimal place
        //float speed = Mathf.Round(rb.velocity.magnitude * 10f) / 10f;

        speed = Mathf.RoundToInt(rb.velocity.magnitude);

        if (speed > highestSpeedThisSession)
        { 
            highestSpeedThisSession = speed;
        }

        if (PortraitManager.Instance.importantFaceEvent == false)
        {
            if (speed < slowSpeed)
            {
                PortraitManager.Instance.NeutralFace();
            }
            else if (speed > slowSpeed && speed < fastSpeed)
            {
                PortraitManager.Instance.GoingSlow();
            }
            else if (speed > fastSpeed)
            {
                PortraitManager.Instance.GoingFast();
            }
        }

        // Display the speed in the UI text
        speedText.text =  speed.ToString();

    }
}