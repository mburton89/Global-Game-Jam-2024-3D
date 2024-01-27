using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRat : MonoBehaviour
{
    public static RunningRat Instance;
    public Transform ball;

    public float yOffset;
    
    void Awake()
    {
        Instance = this;    
    }

    private void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + yOffset, ball.transform.position.z);
    }

    public void MoveUp(float distance)
    {
        yOffset += distance;
    }
}
