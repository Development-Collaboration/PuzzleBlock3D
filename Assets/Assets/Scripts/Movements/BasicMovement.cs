using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public abstract class BasicMovement : MonoBehaviour
{

    protected Rigidbody rb;
    protected GameStatus gameStatus;

    //
    private string stringBlock = "Block";
    private string stingWall = "Wall";
    private string stringGoal = "Goal";
    private string stringGravityTransfer = "GravityTransfer";
    
    //
    [SerializeField] //[Range( , )]
    protected float movementSpeed = 11f;

    //[SerializeField] //[Range( , )]
    protected int movementDistance = 1;

    private float rayDistance = 1.25f;

    protected Vector3 currentPos;
    protected Vector3 targetPos;
    protected bool isMoving = false;

    public bool IsRestricted { get; set; }

    [SerializeField] protected int movementCounts = 0;
    //
    protected List<PointsInTime> pointsInTimes;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        gameStatus = FindObjectOfType<GameStatus>();

        rb.freezeRotation = true;
        isMoving = false;
        IsRestricted = false;

        pointsInTimes = new List<PointsInTime>();

    }

    protected virtual void MovementsControl(DIRECTION direction)
    {

        if ((!isMoving))
        {
            //currentPos = this.transform.position;
            currentPos = rb.position;

            IsRestricted = false;

            // + wall detection
            DirectionDecision(direction);

            // execute at Block.cs
            //MoveBlock(direction);

            if (IsRestricted)
            {
                //targetPos = currentPos;

                print("Restricted");
                targetPos =  transform.TransformDirection(currentPos);

                return;
            }

            ++movementCounts;
            // execute player move
            StartCoroutine("ExecuteMovements");

        }
    }


    IEnumerator ExecuteMovements()
    {

        isMoving = true;

        /*
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
 
            rb.MovePosition(Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime));



            yield return null;

        }

        transform.position = targetPos;
        isMoving = false;
        */


        ///

        /*
        Vector3 newPosition = rb.position + transform.TransformDirection(targetPos);

        while (Vector3.Distance(rb.position, newPosition) > 0.05f)
        {
            rb.MovePosition(newPosition * (movementSpeed * Time.deltaTime));
            yield return null;
        }


        isMoving = false;
        */

        //Vector3 newPosition = rb.position + (transform.TransformDirection(targetPos) * (movementSpeed * Time.deltaTime));

        // Vector3 newPosition = rb.position + (transform.TransformDirection(targetPos * (movementSpeed * Time.deltaTime)));

        //Vector3 destinationPosition = rb.position + transform.TransformDirection(targetPos);



        /*
        while (Vector3.Distance(transform.TransformDirection(rb.position), targetPos) >= 0.05f)
        {
            print("in While");
            print("rb pos" + transform.TransformDirection(rb.position));
            print("target pos" + targetPos);

            rb.MovePosition(targetPos);

            //rb.MovePosition(rb.position + transform.TransformDirection(targetPos * (movementSpeed * Time.deltaTime)));

            //rb.MovePosition((targetPos * (movementSpeed * Time.deltaTime)));

            //rb.MovePosition(Vector3.Lerp(transform.TransformDirection(rb.position), targetPos, movementSpeed * Time.deltaTime));


            yield return null;

        }
        */

        //Vector3 newPosition = rigidbody.position + transform.TransformDirection(localPositionOffset);
        //rigidbody.MovePosition(newPosition);
        /////////////////////

        // 이거됨
        /*
        print(this.name);
        print("Co start");

            print("in While");
            print("rb trans pos" + transform.TransformDirection(rb.position)); // 이거 안맞음

        print("rb pos" + rb.position);

        print("target pos" + targetPos);

            rb.MovePosition(targetPos);

 
        yield return null;


        print("End Co");


        isMoving = false;
        */

        //print(this.name);
        //print("Co start");

        while(Vector3.Distance(rb.position, targetPos) >= 0.05f)
        {
            /*
            print("in While");
            print("rb trans pos" + transform.TransformDirection(rb.position)); // 이거 안맞음

            print("rb pos" + rb.position);

            print("target pos" + targetPos);
            */
            //rb.MovePosition(targetPos);
            rb.MovePosition(Vector3.Lerp(rb.position, targetPos, movementSpeed * Time.deltaTime));

            yield return null;
        }



        print("End Co");

        rb.MovePosition(targetPos);

        isMoving = false;


    }

    protected virtual void DirectionDecision(DIRECTION direction)
    {
        Vector3 rayTransformDirection = Vector3.zero;

        switch (direction)
        {
            case DIRECTION.UR:
                {

                    //print("onmove UR");
                    //targetPos = new Vector3(movementDistance, 0, 0);

                    targetPos = Vector3.right * movementDistance;

                    rayTransformDirection = transform.TransformDirection(Vector3.right);
                }
                break;

            case DIRECTION.DR:
                {
                    //print("onmove DR");
                    //targetPos = new Vector3(0, 0, - movementDistance);
                    targetPos = Vector3.back * movementDistance;


                    rayTransformDirection = transform.TransformDirection(Vector3.back);

                }

                break;

            case DIRECTION.DL:
                {
                    //print("onmove DL");
                    //targetPos = new Vector3( - movementDistance, 0, 0);

                    targetPos = Vector3.left * movementDistance;

                    rayTransformDirection = transform.TransformDirection(Vector3.left);

                }

                break;

            case DIRECTION.UL:
                {
                    //print("onmove UL");

                    //targetPos = new Vector3(0,0, movementDistance);
                    targetPos = Vector3.forward * movementDistance;

                    rayTransformDirection = transform.TransformDirection(Vector3.forward);


                }
                break;
        }



        targetPos = (rb.position + transform.TransformDirection(targetPos));

        targetPos = new Vector3(Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));


        //targetPos = (transform.TransformDirection(rb.position) + transform.TransformDirection(targetPos));


        /*
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

                targetPos = new Vector3
            (Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));

        
        */


        RaycastCheck(rayTransformDirection, direction);


    }

    protected virtual void RaycastCheck(Vector3 rayTransformDirection, DIRECTION direction)
    {
        RaycastHit hit;

        //transform.InverseTransformDirection

        // Wall Detection
        //Debug.DrawRay(transform.position, transform.TransformDirection(rayTransformDirection) * (movementDistance * rayDistance), Color.red, 1.5f);

        // movementDistance * rayDistance
        Debug.DrawRay(transform.position, rayTransformDirection * (movementDistance * rayDistance), Color.red, 2f);


        //if (Physics.Raycast(this.transform.position, transform.TransformDirection(rayTransformDirection),out hit, (movementDistance * rayDistance)))
        if (Physics.Raycast(this.transform.position, rayTransformDirection, out hit, (movementDistance * rayDistance)))
        {
            //print("Hit info: " + hit.transform.tag);

            if (hit.transform.CompareTag(stingWall))
            {
                CollideWithWall(hit);
            }

            if (hit.transform.CompareTag(stringBlock))
            {

                CollideWithBlock(hit, direction);
            }

            if (hit.transform.CompareTag(stringGoal))
            {

                CollideWithGoal(hit);
            }

            //
            if (hit.transform.CompareTag(stringGravityTransfer))
            {

                CollideWithGravityTransfer(hit, direction);
            }

            
        }
        
    }



    protected virtual void CollideWithWall(RaycastHit hit) {  }

    protected virtual void CollideWithBlock(RaycastHit hit, DIRECTION direction)  {  }

    protected virtual void CollideWithGoal(RaycastHit hit) {  }

    protected virtual void CollideWithGravityTransfer(RaycastHit hit, DIRECTION direction) { }

    public void RecordPoints()
    {
        //print("Record: " + this.gameObject.name + " | pos: " + this.transform.position);

        pointsInTimes.Insert(0,
           new PointsInTime(transform.position, transform.rotation, transform.localScale));

    }

    public void RewindPoints()
    {
        if (pointsInTimes.Count > 0)
        {
            //print("Rewind");

            PointsInTime points = pointsInTimes[0];

            transform.position = points.position;
            transform.rotation = points.rotation;
            transform.localScale = points.scale;
            //--movementCounts;

            pointsInTimes.RemoveAt(0);

            
        }
    }


}
