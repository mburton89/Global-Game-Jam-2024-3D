using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockPiece : MonoBehaviour
{
    Rigidbody rb;

    public void Activate()
    {
        transform.parent = null;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        float randXForce = Random.Range(-GameManager.Instance.roadBlockPieceExplosionForce, GameManager.Instance.roadBlockPieceExplosionForce);
        float randYForce = Random.Range(0, GameManager.Instance.roadBlockPieceExplosionForce);
        float randZForce = Random.Range(GameManager.Instance.roadBlockPieceExplosionForce, GameManager.Instance.roadBlockPieceExplosionForce * 5);

        float randXTorque = Random.Range(-GameManager.Instance.roadBlockPieceTorque, GameManager.Instance.roadBlockPieceTorque);
        float randYTorque = Random.Range(-GameManager.Instance.roadBlockPieceTorque, GameManager.Instance.roadBlockPieceTorque);
        float randZTorque = Random.Range(-GameManager.Instance.roadBlockPieceTorque, GameManager.Instance.roadBlockPieceTorque);

        rb.AddForce(new Vector3(randXForce, randYForce, randZForce));
        rb.AddTorque(new Vector3(randXTorque, randYTorque, randZTorque));
    }
}
