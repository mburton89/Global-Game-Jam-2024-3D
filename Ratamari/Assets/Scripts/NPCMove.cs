using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    private float teeterAngle = 10;
    private float teeterSpeed = 5;


    private double hopHeight = .1;
    private float hopSpeed = 10;

    private float waddleDistance = 6;
    private float waddleSpeed = 2;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isGoingUp = true;
    private bool isWaddlingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        // Teetering
        float teeterAngleValue = Mathf.Sin(Time.time * teeterSpeed) * teeterAngle;
        Quaternion teeterRotation = Quaternion.Euler(0f, 0f, teeterAngleValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation * teeterRotation, Time.deltaTime * teeterSpeed);

        // Hopping
        float verticalMovement = (float)(Mathf.Sin(Time.time * hopSpeed) * hopHeight);
        transform.position = initialPosition + new Vector3(transform.position.x, verticalMovement, transform.position.z);

        // Waddling
        Vector3 waddleDirection = isWaddlingRight ? Vector3.right : Vector3.left;
        Vector3 targetPos = isWaddlingRight ? initialPosition + waddleDirection * waddleDistance : initialPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, waddleSpeed * Time.deltaTime);

        // Change waddle direction when reaching the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            isWaddlingRight = !isWaddlingRight;
        }

        // Change hop direction when reaching the peak of the hop
        if (Mathf.Approximately(verticalMovement, (float)hopHeight) || Mathf.Approximately(verticalMovement, (float)-hopHeight))
        {
            isGoingUp = !isGoingUp;
        }
    }
}

