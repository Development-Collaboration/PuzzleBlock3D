using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player_NoR : MonoBehaviour
{
    // Components
    Rigidbody rb;

    //
    [SerializeField] private float speed = 10f;
    [SerializeField] private Vector3 movements = Vector3.zero;

    //
    private float horizontal = 0f;
    private float vertical = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void FixedUpdate()
    {
        // Movements

        //
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 tempPos = rb.transform.position;


        //// Inputs

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.transform.position = new Vector3(tempPos.x, tempPos.y +1,tempPos.z);

            print("Space Pressed");
        }

        //// Move to Button Methods
        

        // x,z Movements
        
        movements.Set(horizontal, 0, vertical);
        movements = movements.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movements);
         



    }
}
