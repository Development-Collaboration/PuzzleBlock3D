using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{

    Rigidbody rb;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
         var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        /*

    transform.Translate(new Vector3(horizontal, 0, vertical) * (10 * Time.deltaTime));
                */
        targetPos.Set(horizontal, 0, vertical);
        targetPos = targetPos.normalized * 10 * Time.deltaTime;



        rb.MovePosition(transform.position + targetPos);


    }
}
