using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTransfer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("hit GravityTransfer");

        Vector3 pos = other.transform.position;

        other.transform.position = new Vector3(pos.x, -2f, 6f);


        if(other.CompareTag("Player"))
        {
            Debug.Log("from GT, P hit this");


        }

    }

    
}
