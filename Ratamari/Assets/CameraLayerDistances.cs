using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLayerDistances : MonoBehaviour
{
    public float smallPropDistance = 150f;
    public float bigPropDistance = 300f;
    public float endGoalPropDistance = 1000f;

    Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[6] = endGoalPropDistance;
        distances[8] = smallPropDistance;
        distances[9] = bigPropDistance;
        camera.layerCullDistances = distances;
    }
}
