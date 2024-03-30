using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject mobileInstruct;
    public GameObject pcInstruct;
    public GameObject currentInstruct;

    public bool isMoblie;

    float aspectRatio;

    private void OnEnable()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (aspectRatio > 1f)
        {
            isMoblie = true;
        }
        else
        {
            isMoblie = false;
        }

        showInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInstructions()
    {
        if (isMoblie)
        {
            currentInstruct = mobileInstruct;
        }
        else
        {
            currentInstruct = pcInstruct;
        }

        currentInstruct.SetActive(true);
    }



}
