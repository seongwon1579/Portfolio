using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMissile : MonoBehaviour
{
    private Rigidbody rb;
    private Transform missileTransform;

    private void Set(Transform transform, Rigidbody rigidbody)
    {
        missileTransform = transform;
        rb = rigidbody;
    }

    public void Project(Transform transform, Rigidbody rigidbody)
    {
        Set(transform, rigidbody);
        Forward();
    }

    private void Forward()
    {
        if (missileTransform == null)
            return;

        rb.velocity = Vector3.zero;
        rb.AddForce(missileTransform.forward * 10f, ForceMode.Impulse);
    }
}
