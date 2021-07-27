using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float orbitGravity;

    public bool fixedDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityControl>())
        {
            // if this object has a gravity script

            other.GetComponent<GravityControl>().gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
