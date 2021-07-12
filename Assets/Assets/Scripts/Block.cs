using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody rb;

    public bool IsBlockCollideWPlayer { get; set; }

    [SerializeField] //[Range( , )]
    private float movementSpeed = 11f;
    private int movementDistance = 1;

    private Vector3 targetPos;
    private bool isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        IsBlockCollideWPlayer = false;
    }

    public void OnBlockMove(DIRECTION direction)
    {
        print("On box move execued form block");

        /*
        this.transform.position = new Vector3
            (transform.position.x, transform.position.y + 2, transform.position.z);
        */

        print("block pos: " + this.transform.position);

        // Player point == player 
        print("block Direction: " + direction);

        if(!isMoving)
        {
            DirectionDecision(direction);

            // execute block move

            StartCoroutine("ExecuteMovements");
        }


    }


    IEnumerator ExecuteMovements()
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {

            rb.MovePosition(Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime));

            yield return null;

        }

        transform.position = targetPos;

        isMoving = false;

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("Exit w P (from block) ");

            IsBlockCollideWPlayer = false;
        }
    }


    private void DirectionDecision(DIRECTION direction)
    {

        isMoving = true;

        switch (direction)
        {
            case DIRECTION.UR:
                {
                    //print("onmove UR");
                    targetPos = new Vector3
                        (transform.position.x + movementDistance, transform.position.y, transform.position.z);

                }
                break;

            case DIRECTION.DR:
                {
                    //print("onmove DR");
                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z - movementDistance);

                }

                break;

            case DIRECTION.DL:
                {
                    //print("onmove DL");
                    targetPos = new Vector3
                        (transform.position.x - movementDistance, transform.position.y, transform.position.z);

                }

                break;

            case DIRECTION.UL:
                {
                    //print("onmove UL");

                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z + movementDistance);

                }
                break;
        }
        //
        targetPos = new Vector3
            ((int)targetPos.x, (int)targetPos.y, (int)targetPos.z);


    }



}
