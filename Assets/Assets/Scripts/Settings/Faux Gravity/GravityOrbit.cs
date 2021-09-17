using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GravityPosition { UP, UL, DOWN, DR, UR, DL }

public class GravityOrbit : MonoBehaviour
{
    public float OrbitGravity { get; set; }

    public bool FixedDirection { get; set; }

    public GravityPosition gravityPos;


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

            other.GetComponent<GravityControl>().gravityOrbit = this.GetComponent<GravityOrbit>();
        }
    }
}
