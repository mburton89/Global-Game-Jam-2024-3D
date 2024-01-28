using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatSelector : MonoBehaviour
{
    public List<GameObject> hats;

    void Start()
    {
        ChooseHat();
    }

    void ChooseHat()
    { 
        int rand = Random.Range(0, hats.Count);

        hats[rand].SetActive(true);
    }
}
