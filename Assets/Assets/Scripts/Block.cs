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

    private bool[] restrictedDirectionArray = new bool[4] { false, false, false, false };

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        IsBlockCollideWPlayer = false;
    }

    public void OnBlockMove(DIRECTION direction)
    {
        //print("On box move execued form block");
        //print("block pos: " + this.transform.position);
        //print("block Direction: " + direction);

        if(!isMoving)
        {
            DirectionDecision(direction);

            // Dont execute if there is block or wall toware that direction
            /*
             if block || wall == target pos
            return false
             */



            // execute block move
            StartCoroutine("ExecuteMovements");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Block") ||
            other.gameObject.CompareTag("Wall"))
        {


        }

    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall")
            ||
            (collision.gameObject.CompareTag("Block") &&
            Vector3.Distance(this.transform.position, collision.transform.position) < 1.01f))
        {
            print("Collided point[0]: " + collision.contacts[0].normal);

            Vector3 _contactPoint = collision.contacts[0].normal;

            print("contactPoint: " + _contactPoint);

            // UL
            if (_contactPoint.z == -1)
            {
                //print("obj is UL on p ");

                CollisionWithRestrictedObject(DIRECTION.UL, collision);


            }

            // DR
            if (_contactPoint.z == 1)
            {
                //print("obj is DR on p ");

                CollisionWithRestrictedObject(DIRECTION.DR, collision);


            }

            // UR
            if (_contactPoint.x == -1)
            {
                //print("obj is UR on p ");
                CollisionWithRestrictedObject(DIRECTION.UR, collision);

            }

            // DL
            if (_contactPoint.x == 1)
            {
                //print("obj is DL on p ");

                CollisionWithRestrictedObject(DIRECTION.DL, collision);
            }

            //// can't find the diff
            //print("Player Collided point[1]: " + collision.contacts[1].normal);
            //print("Player Collided point[2]: " + collision.contacts[2].normal);
            //print("Player Collided point[3]: " + collision.contacts[3].normal);            

        }

    }

    private void CollisionWithRestrictedObject(DIRECTION direction, Collision collision)
    {
        print("collition tag:  " + collision.gameObject.tag);
        print("collition restrictedDirection: " + direction);
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
