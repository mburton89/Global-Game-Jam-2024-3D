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

   public MobileInputHandler mobileInputHandler;
    public Instructions gameInstructions;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialBallRadius = GetComponent<SphereCollider>().radius;
        currentBallSize = 4;

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * initialSpeed, ForceMode.Impulse);
            gameInstructions.currentInstruct.SetActive(false);
        }

        if (moveInput != 0)
        { 
            mobileInputHandler.enabled = false;
        }
        //Jump();

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed) + (moveInput * 4), rb.velocity.y, rb.velocity.z);
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
            currentBallSize += other.GetComponent<PropCollider>().propValue;
            rb.GetComponent<SphereCollider>().radius += other.GetComponent<PropCollider>().propValue;

            cam.GetComponent<CameraFollow>().followPositionOffset.y += other.GetComponent<PropCollider>().propValue;
            cam.GetComponent<CameraFollow>().followPositionOffset.z -= other.GetComponent<PropCollider>().propValue;

            SizeManager.Instance.HandleItemCollected();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // crash into too-big stuff to get smaller
        if (collision.gameObject.CompareTag("Prop"))
        {
            AudioClip clip = collision.gameObject.GetComponent<PropCollider>().CollectableSoundToPlay;
            SoundManager.Instance.PlayAudioClip(clip);

            if (lastZVelocity >= 10 )
            {
                // kick off props from ball on crash based on how impactful the crash was
                float totalPropSize = 0;
                List<GameObject> totalPropsOnBall = new();

                // first, get the actual props currently on ball
                for (var i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).GetComponent<PropCollider>() && !transform.GetChild(i).GetComponent<PropCollider>().isRat)
                    {
                        totalPropsOnBall.Add(transform.GetChild(i).gameObject);
                    }
                }
                
                // and get the count to compare with num of props needed for level up
                float currentCountOfPropsOnBall = totalPropsOnBall.Count;

                // then, kick off props if it is appropriate to do so (if ball is "small" or if ball has more props than num needed to level up)
                for (var i = 0; i < totalPropsOnBall.Count; i++)
                {
                    if (!totalPropsOnBall[i].GetComponent<PropCollider>().isRat && totalPropSize <= Mathf.Floor(lastZVelocity) / 1000 && (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Small || currentCountOfPropsOnBall > SizeManager.Instance.numberOfItemsNeededToCollectBeforeLevelUp))
                    {
                        print("Kicking off a prop! " + totalPropsOnBall[i].name);

                        totalPropSize += totalPropsOnBall[i].GetComponent<PropCollider>().propValue;

                        currentBallSize -= totalPropsOnBall[i].GetComponent<PropCollider>().propValue;
                        rb.GetComponent<SphereCollider>().radius -= totalPropsOnBall[i].GetComponent<PropCollider>().propValue;

                        cam.GetComponent<CameraFollow>().followPositionOffset.y -= totalPropsOnBall[i].GetComponent<PropCollider>().propValue;
                        cam.GetComponent<CameraFollow>().followPositionOffset.z += totalPropsOnBall[i].GetComponent<PropCollider>().propValue;

                        StartCoroutine(KickOffProps(totalPropsOnBall[i]));
                        SizeManager.Instance.HandleItemsLost(1);
                        currentCountOfPropsOnBall--;
                    }
                }

                print("Crashed into larger prop! Removed " + Mathf.Floor(lastZVelocity) / 1000 + " from its size, losing " + Mathf.FloorToInt(lastZVelocity / 10) + " props!");

                // prevent ball from getting toooo small
                if (SizeManager.Instance.currentBallSize == SizeManager.BallSize.Small && currentBallSize < initialBallRadius * 2)
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
                        SizeManager.Instance.HandleItemsLost(totalPropsOnBall.Count);
                    }

                    print("Ball size was limited to what it started at!");
                }
            }

            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                print(collision.gameObject.name);

                if (collision.gameObject.GetComponent<NPCMove>())
                { 
                    collision.gameObject.GetComponent<NPCMove>().enabled = false;
                }
                collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000 * rb.velocity.z);

/*                if (collision.gameObject.GetComponent<GrannyRag>())
                {
                    collision.gameObject.GetComponent<GrannyRag>().EnableRagdoll();
                }*/
            }
        }
    }

    IEnumerator KickOffProps(GameObject prop)
    {
        if (prop.GetComponent<PropCollider>().isRat)
        {
            yield return null;
        }
        else
        {
            prop.transform.SetParent(prop.transform.root);

            yield return new WaitForSeconds(2);
            Destroy(prop);

            yield return null;
        }
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
