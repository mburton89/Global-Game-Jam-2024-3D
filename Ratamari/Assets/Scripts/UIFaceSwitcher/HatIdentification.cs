using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatIdentification : MonoBehaviour
{
    public string hatId;

    void Start()
    {
        PortraitManager.Instance.CheckRatHatId(hatId);        
    }
}
