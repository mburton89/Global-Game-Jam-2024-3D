using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisThingAPerson : MonoBehaviour
{
    void OnCollisionEnter (Collision target) {
     if( target.gameObject.CompareTag("Player") ){
          PortraitManager.Instance.HitPersonFace();
     }
    }
}
