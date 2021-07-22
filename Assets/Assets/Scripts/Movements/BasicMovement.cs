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


    //
    [SerializeField] //[Range( , )]
    protected float movementSpeed = 11f;

    //[SerializeField] //[Range( , )]
    protected int movementDistance = 1;

    protected Vector3 currentPos;
    protected Vector3 targetPos;
    protected bool isMoving = false;

    public bool IsRestricted { get; set; }

    [SerializeField] protected int movementCounts = 0;


    //
    protected List<PointsInTime> pointsInTimes;
    private bool isRecording = false;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        gameStatus = FindObjectOfType<GameStatus>();

        rb.freezeRotation = true;
        isMoving = false;
        IsRestricted = false;

        pointsInTimes = new List<PointsInTime>();

    }

    private void FixedUpdate()
    {
        /*
        if(!gameStatus.IsRecording)
        {
            RecordPoints();

        }
        */

        /*
        if (Input.GetMouseButtonDown(0))
        {
            RecordPoints();
        }

        if (Input.touchCount > 0)
        {
            RecordPoints();

        }
        */
        /*
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
        }
        */

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RecordPoints();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            RewindPoints();
            

        }
    }


    protected virtual void MovementsControl(DIRECTION direction)
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

            ++movementCounts;
            // execute player move
            StartCoroutine("ExecuteMovements");

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

        transform.position = targetPos;
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
        //targetPos = new Vector3
        //    ((int)targetPos.x, (int)targetPos.y, (int)targetPos.z);

        targetPos = new Vector3
            (Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));

        RaycastCheck(rayTransformDirection, direction);


    }

    protected virtual void RaycastCheck(Vector3 rayTransformDirection, DIRECTION direction)
    {
        RaycastHit hit;

        // Wall Detection
        Debug.DrawRay(transform.position, transform.TransformDirection(rayTransformDirection) * movementDistance, Color.red, 0.5f);

        if (Physics.Raycast(this.transform.position, transform.TransformDirection(rayTransformDirection),
            out hit, (movementDistance)))
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


        }
    }



    protected virtual void CollideWithWall(RaycastHit hit) {  }

    protected virtual void CollideWithBlock(RaycastHit hit, DIRECTION direction)  {  }

    protected virtual void CollideWithGoal(RaycastHit hit) {  }


    public void RecordPoints()
    {
        print("Record: " + this.gameObject.name + " | pos: " + this.transform.position);

        pointsInTimes.Insert(0,
           new PointsInTime(transform.position, transform.rotation));

    }

    public void RewindPoints()
    {
        if (pointsInTimes.Count > 0)
        {
            print("Rewind");

            PointsInTime points = pointsInTimes[0];

            transform.position = points.position;
            transform.rotation = points.rotation;

            pointsInTimes.RemoveAt(0);

            --movementCounts;
        }
    }


}
