using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    [HideInInspector]
    public GravityOrbit gravityOrbit;
    private Rigidbody rb;

    //public float rotationSpeed = 20f;

    public GRAVITYPOSITION GravityPos { get; set; }



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }



    private void FixedUpdate()
    {
        // fixed

        if (null != gravityOrbit)
        {
            Vector3 gravityUP = Vector3.zero;
            //

            if (gravityOrbit.FixedDirection)
            {
                gravityUP = gravityOrbit.transform.up;
            }
            else
            {
                gravityUP = (transform.position - gravityOrbit.transform.position).normalized;

            }

            //
            Vector3 localUp = transform.up;

            Quaternion tragetRotation = Quaternion.FromToRotation(localUp, gravityUP) * transform.rotation;

            rb.MoveRotation(tragetRotation);


            // push down
            rb.AddForce((gravityUP * -gravityOrbit.OrbitGravity) * rb.mass);


            GravityPos = gravityOrbit.gravityPos;

        }
        /*
        else if (null == gravity)
        {
            rb.AddForce(Vector3.zero);
        }
        */

    }

 
}


