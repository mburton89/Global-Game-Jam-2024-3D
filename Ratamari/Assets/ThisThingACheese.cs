using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisThingACheese : MonoBehaviour
{
    void OnTriggerEnter (Collider target) {
     if( target.CompareTag("Player") ){
          PortraitManager.Instance.CollectCheeseFace();
     }
    }
}
