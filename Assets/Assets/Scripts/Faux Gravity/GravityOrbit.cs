using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float OrbitGravity { get; set; }

    public bool FixedDirection { get; set; }

    private void Awake()
    {
        OrbitGravity = 10f;
        FixedDirection = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityControl>())
        {
            // if this object has a gravity script

            other.GetComponent<GravityControl>().gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
