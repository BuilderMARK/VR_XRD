using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportBelt : MonoBehaviour
{
    public float speed = 1.0f;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null )
        {
            rb.velocity = transform.right * speed;
        }
    }
}
