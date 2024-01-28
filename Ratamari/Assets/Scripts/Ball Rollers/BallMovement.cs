using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    public Camera cam;

    public float maxMoveSpeed;
    public float initialSpeed; // how much speed the ball has when launching off the hill
    public float jumpForce;
    public float currentZVelocity;
    float lastZVelocity;
    public float currentBallSize;
    float initialBallRadius;

    public int maxJumps;
    public int currentJumps;
    public LayerMask groundLayer;

    public bool isGrounded;
    public bool movedForward;

    float moveInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialBallRadius = GetComponent<SphereCollider>().radius;
        currentBallSize = 1;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * initialSpeed, ForceMode.Impulse);
        }

        //Jump();

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed) + (moveInput / 1.5f), rb.velocity.y, rb.velocity.z);
        currentZVelocity = rb.velocity.z;
        lastZVelocity = rb.velocity.z;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumps > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                currentJumps--;
            }
        }

        if (rb.velocity.y <= 0)
        {
            CheckIfGrounded();
        }
    }

    public void CheckIfGrounded()
    {
        // draw an imaginary line from the player (ball) center downwards. if the line touches an object on the ground layer, consider ourselves grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (GetComponent<SphereCollider>().radius * 2) + 0.05f);
        ResetJumps();
    }

    public void ResetJumps()
    {
        if (isGrounded && currentJumps != maxJumps)
        {
            currentJumps = maxJumps;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // pick up props to get bigger
        if (other.gameObject.CompareTag("Prop") && !other.GetComponent<PropCollider>().pickedUp)
        {
            if (!CheckIfCanPickUp(other.GetComponent<PropCollider>())) return;

            other.transform.parent = transform;
            other.GetComponent<PropCollider>().pickedUp = true;
            currentBallSize += other.GetComponent<PropCollider>().propSize;
            rb.GetComponent<SphereCollider>().radius += other.GetComponent<PropCollider>().propSize;

            cam.GetComponent<CameraFollow>().followPositionOffset.y += other.GetComponent<PropCollider>().propSize;
            cam.GetComponent<CameraFollow>().followPositionOffset.z -= other.GetComponent<PropCollider>().propSize;

            SizeManager.Instance.HandleItemCollected();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // crash into too-big stuff to get smaller
        if (collision.gameObject.CompareTag("Prop"))
        {
            if (lastZVelocity >= 10)
            {
                print("Crashed into larger prop! Removed " + lastZVelocity / 100 + " from its size!");

                currentBallSize -= lastZVelocity / 100;
                rb.GetComponent<SphereCollider>().radius -= lastZVelocity / 100;

                cam.GetComponent<CameraFollow>().followPositionOffset.y -= lastZVelocity / 100;
                cam.GetComponent<CameraFollow>().followPositionOffset.z += lastZVelocity / 100;

                // kick off props from ball on crash based on how impactful the crash was
                float totalPropSize = 0;

                for (var i = 0; i < transform.childCount; i++)
                {
                    print("Kicking off a prop!" + transform.GetChild(i).gameObject.name);
                    totalPropSize += transform.GetChild(i).GetComponent<PropCollider>().propSize;
                    if (totalPropSize <= lastZVelocity)
                    {
                        StartCoroutine(KickOffProps(transform.GetChild(i).gameObject));
                    }

                    SizeManager.Instance.HandleItemsLost(1);
                }

                // prevent ball from getting toooo small
                if (currentBallSize < initialBallRadius * 2)
                {
                    currentBallSize = initialBallRadius * 2;
                    rb.GetComponent<SphereCollider>().radius = initialBallRadius;

                    cam.GetComponent<CameraFollow>().followPositionOffset.y = cam.GetComponent<CameraFollow>().initialFollowPositionOffset.y;
                    cam.GetComponent<CameraFollow>().followPositionOffset.z = cam.GetComponent<CameraFollow>().initialFollowPositionOffset.z;

                    // kick off all props from ball
                    for (var i = 0; i < transform.childCount; i++)
                    {
                        print("Kicking off all props!");
                        StartCoroutine(KickOffProps(transform.GetChild(i).gameObject));
                    }

                    print("Ball size was limited to what it started at!");
                }
            }
        }
    }

    IEnumerator KickOffProps(GameObject prop)
    {
        prop.transform.SetParent(prop.transform.root);

        yield return new WaitForSeconds(2);
        Destroy(prop);

        yield return null;
    }

    // debug function: draws line from ball's center downwards, visualizes ground check
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new(transform.position.x, transform.position.y - (GetComponent<SphereCollider>().radius * 2) - 0.05f, transform.position.z));
    }

    bool CheckIfCanPickUp(PropCollider prop)
    {
        if (prop.size == PropCollider.Size.Medium)
        {
            if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Medium || SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (prop.size == PropCollider.Size.Large)
        {
            if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Large)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}
