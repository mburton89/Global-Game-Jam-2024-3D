using UnityEngine;
using UnityEngine.UI;

public class CharacterSwapper : MonoBehaviour
{
    public GameObject character1; // Assign the first character GameObject in the Inspector
    public GameObject character2; // Assign the second character GameObject in the Inspector
    public Toggle characterToggle; // Assign the Toggle UI element in the Inspector
    public Transform target; // The target object to follow
    private Vector3 initialOffset; // Initial offset from the target
    private Quaternion initialRotation; // Initial rotation relative to the target
    private float initialTargetX; // Initial X position of the target
    public GameObject Charactertoggle;

    void Start()
    {
        // Add listener for when the state of the Toggle changes
        characterToggle.onValueChanged.AddListener(OnToggleValueChanged);

        // Initialize the characters based on the initial state of the Toggle
        OnToggleValueChanged(characterToggle.isOn);

        // Calculate the initial offset and rotation
        initialOffset = character1.transform.position - target.position;
        initialRotation = Quaternion.Inverse(target.rotation) * character1.transform.rotation;

        // Store the initial X position of the target
        initialTargetX = target.position.x;
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            character1.SetActive(false);
            character2.SetActive(true);
        }
        else
        {
            character1.SetActive(true);
            character2.SetActive(false);
        }
    }

    void LateUpdate()
    {
          // Check if the target has moved 3 units along the X-axis
        if (Mathf.Abs(target.position.x - initialTargetX) >= 3f)
        {
            Charactertoggle.SetActive(false); // Disable the Toggle
        }
    }
}
