using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSmall : MonoBehaviour
{
    public Vector3 minScale;
    float size = 1f;

    // Start is called before the first frame update
    void Start()
    {
        minScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prop") && collision.transform.localScale.magnitude > size)
        {
            if (GetComponent<Rigidbody>().velocity.z >= 10) 
            {
                size -= GetComponent<Rigidbody>().velocity.z / 10;
            }
        }
    }
}
