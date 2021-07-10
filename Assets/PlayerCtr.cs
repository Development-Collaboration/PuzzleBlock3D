using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    private Rigidbody rb;

    private TouchCtr touchCtr;

    private float speed = 50f;


    public int testing = 0;
    public int limit = 100;

    public float waitTime = 2f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        touchCtr = GetComponent<TouchCtr>();

        // rb.velocity
        // rb.MovePosition
    }

    private void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("Space");
            rb.velocity = rb.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W");
            rb.velocity = rb.transform.forward * 5f ;
            //rb.MovePosition(rb.transform.forward * 5f);
        }
    }

    public void OnMovePlayer(TouchCtr.Direction direction)
    {
        
        switch (direction)
        {
            //    public enum Direction { UR,DR,DL,UL}

            case TouchCtr.Direction.UR:

                break;
            case TouchCtr.Direction.DR:
                break;
            case TouchCtr.Direction.DL:
                break;
            case TouchCtr.Direction.UL:
                {
                    //StartCoroutine("Move");                  
                    
                }
                break;

        }

    }

    /*
    IEnumerator Move()
    {
        
        print("corou start");

        Vector3 currentPos = rb.transform.position;

        Vector3 targetPos = new Vector3(currentPos.x, currentPos.y, currentPos.z + 1);

        //rb.MovePosition(new Vector3(rb.position.x, rb.position.y, rb.position.z + 1));
        Vector3 up = new Vector3(0, 0, 1);


        testing = 0;

        while (true)
        {
            ++testing;

            print("corou In While: " + testing);

            rb.MovePosition(transform.position + (up * speed * Time.deltaTime));

            print("Current Pos: " + transform.position);
            print("Target Pos: " + targetPos);
            

            if (transform.position.z > targetPos.z)
            {
                print("pos reached");
                break;

            }

            if(Time.time > 3f)
            {
                print("time UP");
                break;
            }

            
            if(testing > limit)
            {
                print("num reached: testing: " + testing + " | limit: " + limit);
                break;
            }
            

        }

        print("Out While in Corou");

        yield return new WaitForSeconds(waitTime);


        //yield return null;


        print("corou END");

    }

    */




}
