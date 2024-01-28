using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockPiece : MonoBehaviour
{
    Rigidbody rb;

    float initialForce = 10f;
    float initialTorque = 10f;

    public void Activate(float force)
    {
        transform.parent = null;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        float randXForce = Random.Range(-initialForce * force, initialForce * force);
        float randYForce = Random.Range(0, initialForce * force);
        float randZForce = Random.Range(initialForce * force, initialForce * 5 * force);

        float randXTorque = Random.Range(-initialTorque * force, initialTorque * force);
        float randYTorque = Random.Range(-initialTorque * force, initialTorque * force);
        float randZTorque = Random.Range(-initialTorque * force, initialTorque * force);

        rb.AddForce(new Vector3(randXForce, randYForce, randZForce));
        rb.AddTorque(new Vector3(randXTorque, randYTorque, randZTorque));
    }
}
