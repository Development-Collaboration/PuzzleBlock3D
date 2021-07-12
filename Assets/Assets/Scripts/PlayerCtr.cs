using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    private Rigidbody rb;
    //private TouchCtr touchCtr;
    //

    [SerializeField] //[Range( , )]
    private float movementSpeed = 11f;

    //[SerializeField] //[Range( , )]
    private int movementDistance = 1;

    private Vector3 targetPos;
    private bool isMoving = false;

    private Block[] blockArrays = new Block[4];


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //touchCtr = GetComponent<TouchCtr>();

        //
        rb.freezeRotation = true;
        
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

    public void OnPLayerMovementDirection(DIRECTION direction)
    {
        if((!isMoving))
        {
            isMoving = true;

            DirectionDecision(direction);

            // execute at Block.cs
            MoveBlock(direction);

            // execute player move
            StartCoroutine("ExecuteMovements");

        }
    }


    private void MoveBlock(DIRECTION direction)
    {
        if(null != blockArrays[(int)direction])
        {
            if(true == blockArrays[(int)direction].IsBlockCollideWPlayer)
            {
                blockArrays[(int)direction].OnBlockMove(direction);
            }
            else
            {
                print("player 에서 block null 처리" + direction);
                blockArrays[(int)direction] = null;
            }

        }

        

    }

    IEnumerator ExecuteMovements()
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            //print("Dis: " + Vector3.Distance(transform.position, targetPos));

            rb.MovePosition(Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime));

            yield return null;

        }

        // ??? Edit ???
        transform.position = targetPos;

        /*
        transform.position = new Vector3
            ((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
        */
        //

        /*
        print("Pos: " + transform.position);
        print("TarPos: " + targetPos);

        print("end co");
        */
        isMoving = false;

    }

    
    void OnCollisionStay(Collision collision)
    {
     
        if(collision.gameObject.CompareTag("Block") &&
            Vector3.Distance(this.transform.position, collision.transform.position) < 1.01f)
        {            
            //print("Player Collided point[0]: " + collision.contacts[0].normal);

            Vector3 _contactPoint = collision.contacts[0].normal;

            //print("contactPoint: " + _contactPoint);

            // UL
            if (_contactPoint.z == -1)
            {
                //print("obj is UL on p ");

                CollisionWithBlock(DIRECTION.UL, collision);


            }

            // DR
            if (_contactPoint.z == 1)
            {
                //print("obj is DR on p ");

                CollisionWithBlock(DIRECTION.DR, collision);


            }

            // UR
            if (_contactPoint.x == -1)
            {
                //print("obj is UR on p ");
                CollisionWithBlock(DIRECTION.UR, collision);

            }

            // DL
            if (_contactPoint.x == 1)
            {
                //print("obj is DL on p ");

                CollisionWithBlock(DIRECTION.DL, collision);
            }

            //// can't find the diff
            //print("Player Collided point[1]: " + collision.contacts[1].normal);
            //print("Player Collided point[2]: " + collision.contacts[2].normal);
            //print("Player Collided point[3]: " + collision.contacts[3].normal);            

        }
        

        //Contacs pos info
        // when contact find where this.gameobject is at
        // obj is up on player z== -1
        // "" down on p z== 1
        // ""right on p x == -1
        // "" Left on p x == 1
    }


    private void CollisionWithBlock(DIRECTION direction, Collision collision)
    {
        blockArrays[(int)direction] = collision.gameObject.GetComponent<Block>();
        blockArrays[(int)direction].IsBlockCollideWPlayer = true;


    }


    //
    /*
    private void OnCollisionExit(Collision collision)
    {

        print("No longer in contact with " + collision.transform.name);
        print(": " + collision.transform.tag);


        if (collision.transform.CompareTag("Block"))
        {
            print("colide exit");


            print("Player Collided point[0]: " + collision.contacts[0].normal);

            Vector3 _exitPoint = collision.contacts[0].normal;

            print("_exitPoint: " + _exitPoint);


        }
    }
    */
}
