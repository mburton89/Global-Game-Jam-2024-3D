using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaddle : MonoBehaviour
{
    public float waddleDistance = 5f;
    public float waddleSpeed = 2f;

    private Vector3 startPos;
    private bool isMovingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Waddle();
    }

    void Waddle()
    {
        Vector3 targetPos = isMovingRight ? startPos + new Vector3(waddleDistance, 0, 0) : startPos;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, waddleSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            isMovingRight = !isMovingRight;
        }
    }
}
