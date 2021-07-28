using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Vector3 pos = other.transform.position;

        other.transform.position = new Vector3(pos.x, this.transform.position.y-1f, other.transform.position.z +1);
        print("hit test");
    }
}
