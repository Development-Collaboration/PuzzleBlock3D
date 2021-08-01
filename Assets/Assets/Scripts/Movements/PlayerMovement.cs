using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BasicMovement
{


    //
    private BlockMovement[] blockArrays = new BlockMovement[4];

    #region OldMovement Before BasciMovements.script
    /*
    public bool isRewinding = false;
    private List<Vector3> positions;
    */

    //private List<PointsInTime> pointsInTime;

    /*
    private void Start()
    {
        //positions = new List<Vector3>();
        //rb = GetComponent<Rigidbody>();

        pointsInTime = new List<PointsInTime>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Record");

            pointsInTime.Insert(0,
                new PointsInTime(transform.position, transform.rotation));

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(pointsInTime.Count > 0)
            {
                print("Rewind");

                PointsInTime points = pointsInTime[0];

                transform.position = points.position;
                transform.rotation = points.rotation;

                pointsInTime.RemoveAt(0);
            }

        }

    }
    */
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Record");
            positions.Insert(0, transform.position);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Rewind");
            transform.position = positions[0];
            positions.RemoveAt(0);

        }

    }
    */

    /*
    private void Rewind()
    {
        if(positions.Count>0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);

        }
        else
        {
            StopRewind();
        }
    }

    private void Record()
    {
        positions.Insert(0, transform.position);

        foreach (var pos in positions)
        {
            print("pos: " + pos);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();

    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            print("Rewinding");
            Rewind();

        }
        else
        {
            print("recording");
            Record();

        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }
    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    */

    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnPLayerMovementDirection(DIRECTION direction)
    {
        base.MovementsControl(direction);

        gameStatus.PlayerMovementCount(movementCounts);
    }


    protected override void CollideWithWall(RaycastHit hit)
    {
        IsRestricted = true;

    }

    protected override void CollideWithBlock(RaycastHit hit, DIRECTION direction)
    {
        print(this.name + " Hit: " + hit.transform.name);


        blockArrays[(int)direction] = hit.collider.GetComponent<BlockMovement>();
        blockArrays[(int)direction].OnBlockMovementDirection(direction);
        blockArrays[(int)direction] = null;
    }

    protected override void CollideWithGoal(RaycastHit hit)
    {
        //base.CollideWithGoal(hit);

        IsRestricted = true;

    }

    protected override void CollideWithGravityTransfer(RaycastHit hit, DIRECTION direction)
    {
        // raycheck from GT
        base.CollideWithGravityTransfer(hit, direction);


        if (gravityTransfer.IsGoodToGo)
        {
            //test tele
            targetPos = rb.position + (transform.forward * movementDistance) + Vector3.down;
            targetPos = new Vector3(Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));

            rb.position = targetPos;

            gravityTransfer.IsGoodToGo = false;

            // rotate object

        }
        else
        {
            IsRestricted = true;

        }

    }




}