using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHop : MonoBehaviour
{
    private double hopHeight = .3;
    private float hopSpeed = 5;

    private Vector3 initialPosition;
    private bool isGoingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Hop();
    }

    void Hop()
    {
        double verticalMovement = Mathf.Sin(Time.time * hopSpeed) * hopHeight;

        transform.position = initialPosition + new Vector3(transform.position.x, (float)verticalMovement, transform.position.z);

        if (Mathf.Approximately((float)verticalMovement, (float)hopHeight) && Mathf.Approximately((float)verticalMovement, (float)-hopHeight))
        {
            isGoingUp = !isGoingUp;
        }
    }
}
