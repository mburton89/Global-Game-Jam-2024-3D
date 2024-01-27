using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 followPositionOffset;
    [HideInInspector] public Vector3 initialFollowPositionOffset;

    private void Start()
    {
        initialFollowPositionOffset = followPositionOffset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTarget.position + followPositionOffset;
    }
}
