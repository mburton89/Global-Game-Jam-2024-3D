using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisThingACar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter (Collider target) {
     if( target.CompareTag("Player") ){
          PortraitManager.Instance.HitCarFace();
     }
    }
}
