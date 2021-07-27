using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Vector3 pos = other.transform.position;

        other.transform.position = new Vector3(pos.x, -1.6f, 6f);
        print("hit test");
    }
}
