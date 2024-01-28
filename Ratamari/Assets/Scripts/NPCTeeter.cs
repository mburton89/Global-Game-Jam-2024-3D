using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTeeter : MonoBehaviour
{
    private float teeterAngle = 10f;

    private float teeterSpeed = 5f;

    private Quaternion initialRotation;
    private float teeterDirection = 1f;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Teeter();
    }

    void Teeter()
    {
        float angle = Mathf.Sin(Time.time * teeterSpeed) * teeterAngle * teeterDirection;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation * targetRotation, Time.deltaTime * teeterSpeed);
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //if (Mathf.Abs(angle) >= teeterAngle - 0.1f)
        //{
          //  teeterDirection *= -1f;
        //}
    }
}
