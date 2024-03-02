using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }
}
