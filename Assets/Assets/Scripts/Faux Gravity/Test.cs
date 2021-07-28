using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Vector3 pos = other.transform.position;

        other.transform.position = new Vector3(pos.x, -2f, 7f);
        print("hit test");
    }
}
