using UnityEngine;

public class Mecha : MonoBehaviour
{
    public Transform target; // The target object to follow
    private Vector3 initialOffset; // Initial offset from the target
    

    void Start()
    {
        // Calculate the initial offset and rotation
        initialOffset = transform.position - target.position;
        
    }

    void LateUpdate()
    {
        // Maintain the same distance
        transform.position = target.position + initialOffset;

        
       
    }
}