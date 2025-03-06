using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformThinking : MonoBehaviour
{
    public float timeOnPlatform;
    private bool isColliding = false;

    void Update()
    {
        if (isColliding)
        {
            timeOnPlatform += Time.deltaTime;

            if (timeOnPlatform > 10f)
            {
                PortraitManager.Instance.ThinkingFace();
            }
        }
    }

    void OnTriggerEnter (Collider target) {
     if( target.CompareTag("Player") ){
          isColliding = true;
          timeOnPlatform = 0f;
     }
    }

     void OnTriggerExit (Collider target)
     {
        isColliding = false;
        timeOnPlatform = 0f;
        PortraitManager.Instance.thinkingFaceOn = false;
        PortraitManager.Instance.importantFaceEvent = false;
     }
}
