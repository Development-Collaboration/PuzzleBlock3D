using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision collision)
    {
        print("Points colliding: " + collision.contacts.Length);
        print("First normal of the point that collide: " + collision.contacts[0].normal);

    }

    private bool test = false;
    //testing
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            test = true;
        }


        if(test)
        {
            //rb.transform.position += transform.forward * 2;

            rb.MovePosition(Vector3.Lerp
                (transform.position, new Vector3(0,0,0), 10f * Time.deltaTime));

        }


    }


}
