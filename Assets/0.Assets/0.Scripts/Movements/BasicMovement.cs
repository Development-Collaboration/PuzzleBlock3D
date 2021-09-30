using System.Collections.Generic;
using UnityEngine;

public abstract class BasicMovement : MonoBehaviour
{

    protected Rigidbody rb;
    protected GameStatus gameStatus;


    //
    protected const string stringBlock = "Block";
    protected const string stringWall = "Wall";
    protected const string stringGoal = "Goal";
    protected const string stringGravityTransfer = "GravityTransfer";
    protected const string stringNothing = "Nothing";

    protected const string stringRestriectedBlock = "RestriectedBlock";

    //
    protected string stringCurrent = "";



    //
    [SerializeField] //[Range( , )]
    protected float movementSpeed = 2f;

    //[SerializeField] //[Range( , )]
    protected int movementDistance = 1;

    private float rayDistance = 1.25f;

    protected Vector3 currentPos;
    protected Vector3 targetPos;

    public bool IsMoving { get; set; }

    public bool IsRestricted { get; set; }


    protected GravityTransfer gravityTransfer;

    [SerializeField] protected int movementCounts = 0;
    //
    protected List<PointsInTime> pointsInTimes;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        gameStatus = FindObjectOfType<GameStatus>();

        rb.freezeRotation = true;
        IsMoving = false;
        IsRestricted = false;

        pointsInTimes = new List<PointsInTime>();
    }


    protected virtual void DirectionDecision(DIRECTION direction)
    {
        //Vector3 rayTransformDirection = Vector3.zero;

        switch (direction)
        {
            case DIRECTION.UR:               
                    transform.forward = Vector3.right;                
                break;

            case DIRECTION.DR:
                    transform.forward = Vector3.back;
                break;

            case DIRECTION.DL:
                    transform.forward = Vector3.left;            
                break;

            case DIRECTION.UL:                
                    transform.forward = Vector3.forward;                
                break;

            case DIRECTION.DOWN:                
                    transform.forward = Vector3.down;                
                break;

        }

        //rayTransformDirection = transform.TransformDirection(transform.forward);
        //rayTransformDirection = transform.forward;

        targetPos = rb.position + (transform.forward * movementDistance);
        targetPos = new Vector3(Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));


    }

    protected virtual void RaycastCheck(Vector3 rayTransformDirection, DIRECTION direction)
    {
        RaycastHit hit;

        float rayMaxDistance = (movementDistance * rayDistance);

        //Debug.DrawRay(transform.position, rayTransformDirection * rayMaxDistance, Color.red, 2f);
        //Debug.DrawRay(transform.position, rayTransformDirection * 10f, Color.red, 2f);

        //if (Physics.Raycast(this.transform.position, transform.TransformDirection(rayTransformDirection),out hit, (movementDistance * rayDistance)))

        if (Physics.Raycast(this.transform.position, rayTransformDirection, out hit, rayMaxDistance))
        {
            Debug.Log("Hit info: " + hit.transform.tag);

            stringCurrent = hit.transform.tag;

            if (hit.transform.CompareTag(stringBlock))
            {

                CollideWithBlock(hit, direction);
            }

            else if (hit.transform.CompareTag(stringGravityTransfer))
            {

                CollideWithGravityTransfer(hit, direction);
            }
            else if (hit.transform.CompareTag(stringWall))
            {
                CollideWithWall(hit);
            }

            else if (hit.transform.CompareTag(stringGoal))
            {

                CollideWithGoal(hit);
            }
            
        }
        else
        {
            stringCurrent = stringNothing;
        }
        
    }



    protected virtual void MovementsControl(DIRECTION direction)  {  }
    protected virtual void CollideWithWall(RaycastHit hit) {  }
    protected virtual void CollideWithBlock(RaycastHit hit, DIRECTION direction) { }
    protected virtual void CollideWithGoal(RaycastHit hit) {  }

    protected virtual void CollideWithGravityTransfer(RaycastHit hit, DIRECTION direction)
    {
        gravityTransfer = hit.collider.GetComponent<GravityTransfer>();
        Vector3 tarPos = rb.position + (transform.forward * movementDistance);
        gravityTransfer.RayCheck(tarPos, this.transform.tag);

    }


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
