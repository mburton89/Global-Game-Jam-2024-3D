using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRat : MonoBehaviour
{
    public static RunningRat Instance;
    public Transform ball;

    public float yOffset;
    
    public Animator animator;

    public float distanceToMoveVertically;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + yOffset, ball.transform.position.z);
        animator.speed = ball.GetComponent<Rigidbody>().linearVelocity.magnitude / 20f;
        
    }

    public void MoveUp()
    {
        yOffset += distanceToMoveVertically;
    }

    public void MoveDown()
    {
        yOffset += distanceToMoveVertically;
    }
}
