using UnityEngine;

public class AspectRatioSwitch : MonoBehaviour
{
    public GameObject gameObjectA; // Assign in Inspector
    public GameObject gameObjectB; // Assign in Inspector

    void Start()
    {
        float aspectRatio = (float)Screen.width / Screen.height;

        // Check if the aspect ratio is more vertical than 1:1 or wider than 1:1
        if (aspectRatio > 1f) // Wider than 1:1 (landscape)
        {
            // If it's wider, enable gameObjectA and disable gameObjectB
            if (gameObjectA != null)
                gameObjectA.SetActive(true);
            if (gameObjectB != null)
                gameObjectB.SetActive(false);
        }
        else // More vertical than 1:1 (portrait)
        {
            // If it's more vertical, do the opposite
            if (gameObjectA != null)
                gameObjectA.SetActive(false);
            if (gameObjectB != null)
                gameObjectB.SetActive(true);
        }
    }
}