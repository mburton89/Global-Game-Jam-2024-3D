using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Portrait
{
    public string id;
    public string title;
    public GameObject portrait;
}

public class PortraitManager : MonoBehaviour
{
    public GameObject currentFace;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SwitchPortrait(GameObject faceToSwapIn)
    {
        currentFace.SetActive(false);
        currentFace = faceToSwapIn;
        currentFace.SetActive(true);
    }
}