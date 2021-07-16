using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    private Rigidbody rb;
    //private TouchCtr touchCtr;
    //

    private string block = "Block";
    private string wall = "Wall";

    [SerializeField] //[Range( , )]
    private float movementSpeed = 11f;

    //[SerializeField] //[Range( , )]
    private int movementDistance = 1;


    private Vector3 currentPos;
    private Vector3 targetPos;
    private bool isMoving = false;

    private Block[] blockArrays = new Block[4];

    //
    //private bool[] isRestrictedDirectionArray = new bool[4] { false, false, false, false };

    public bool IsRestricted { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isMoving = false;
        IsRestricted = false;


    }

    
    public void OnPLayerMovementDirection(DIRECTION direction)
    {
        if ((!isMoving))
        {
            currentPos = this.transform.position;
            IsRestricted = false;


            // + wall detection
            DirectionDecision(direction);                

            // execute at Block.cs
            //MoveBlock(direction);

            if (IsRestricted)
            {
                targetPos = currentPos;
                return;
            }

            // execute player move
            StartCoroutine("ExecuteMovements");

        }
    }

    private void DirectionDecision(DIRECTION direction)
    {
        RaycastHit hit;
        Vector3 rayTransformDirection = Vector3.zero;

        switch (direction)
        {
            case DIRECTION.UR:
                {
                    //print("onmove UR");
                    targetPos = new Vector3
                        (transform.position.x + movementDistance, transform.position.y, transform.position.z);

                    rayTransformDirection = transform.TransformDirection(Vector3.right);
                }
                break;

            case DIRECTION.DR:
                {
                    //print("onmove DR");
                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z - movementDistance);

                    rayTransformDirection = transform.TransformDirection(Vector3.back);

                }

                break;

            case DIRECTION.DL:
                {
                    //print("onmove DL");
                    targetPos = new Vector3
                        (transform.position.x - movementDistance, transform.position.y, transform.position.z);

                    rayTransformDirection = transform.TransformDirection(Vector3.left);

                }

                break;

            case DIRECTION.UL:
                {
                    //print("onmove UL");

                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z + movementDistance);

                    rayTransformDirection = transform.TransformDirection(Vector3.forward);

                }
                break;
        }
        //
        targetPos = new Vector3
            ((int)targetPos.x, (int)targetPos.y, (int)targetPos.z);


        // Wall Detection

        Debug.DrawRay(transform.position, transform.TransformDirection(rayTransformDirection) * movementDistance, Color.red, 0.5f);      

        if (Physics.Raycast(this.transform.position, transform.TransformDirection(rayTransformDirection),
            out hit, (movementDistance)))
        {
            print("Hit info: " + hit.transform.tag);

            if (hit.transform.CompareTag(wall))
            {
                print("Wall Dectected");

                IsRestricted = true;

            }

            if(hit.transform.CompareTag(block))
            {
                //
                blockArrays[(int)direction] = hit.collider.GetComponent<Block>();

                //                
                blockArrays[(int)direction].OnBlockMove(direction);

                //
                blockArrays[(int)direction] = null;


            }
        }   



    }

 

    IEnumerator ExecuteMovements()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {

            rb.MovePosition(Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime));

            yield return null;
        }       

        // ??? Edit ???
        transform.position = targetPos;
        isMoving = false;


    }

    /*
    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag(block) &&
        Vector3.Distance(this.transform.position, collision.transform.position) < 1.01f)
        {            
            //print("Player Collided point[0]: " + collision.contacts[0].normal);

            Vector3 _contactPoint = collision.contacts[0].normal;

            //print("contactPoint: " + _contactPoint);

            // UL
            if (_contactPoint.z == -1)
            {
                CollisionWithBlock(DIRECTION.UL, collision);
            }

            // DR
            if (_contactPoint.z == 1)
            {
                CollisionWithBlock(DIRECTION.DR, collision);
            }

            // UR
            if (_contactPoint.x == -1)
            {
                CollisionWithBlock(DIRECTION.UR, collision);
            }

            // DL
            if (_contactPoint.x == 1)
            {
                CollisionWithBlock(DIRECTION.DL, collision);
            }
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
        blockArrays[(int)direction].IsBlockCollideWithPlayer = true;
    }

    
    private void MoveBlock(DIRECTION direction)
    {

         //
         if(null != blockArrays[(int)direction])
         {
             if(true == blockArrays[(int)direction].IsBlockCollideWithPlayer)
             {
                 blockArrays[(int)direction].OnBlockMove(direction);
             }
             else
             {
                 //print("player 에서 block null 처리" + direction);
                 blockArrays[(int)direction] = null;
             }

         }        

     }
    */
     

}
