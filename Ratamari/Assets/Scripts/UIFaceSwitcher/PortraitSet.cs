using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Portrait
{
    public string id;
    public GameObject portrait;
}

public class PortraitSet : MonoBehaviour
{
    public List<Portrait> portraits = new List<Portrait>();
    
    public string setID;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
