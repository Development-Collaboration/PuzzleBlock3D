using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public GravityOrbit gravity;
    private Rigidbody rb;

    public float rotationSpeed = 20f;

    GravityOrbit currentG = null;
    GravityOrbit nextG = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // fixed

        if (null != gravity)
        {
            Vector3 gravityUP = Vector3.zero;
            //

            if (gravity.fixedDirection)
            {
                gravityUP = gravity.transform.up;
            }
            else
            {
                gravityUP = (transform.position - gravity.transform.position).normalized;

            }

            //
            Vector3 localUp = transform.up;

            Quaternion tragetRotation = Quaternion.FromToRotation(localUp, gravityUP) * transform.rotation;

            rb.MoveRotation(tragetRotation);


            // push down
            rb.AddForce((gravityUP * -gravity.orbitGravity) * rb.mass);
        }
        /*
        else if (null == gravity)
        {
            rb.AddForce(Vector3.zero);
        }
        */

    }
}
