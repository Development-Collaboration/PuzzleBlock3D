using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : BasicMovement
{
    private GravityControl gravityControl;

    private GRAVITYPOSITION lastGravityPosition;

    private AllGameObjectsTransform allGameObjectsTransform;
    private bool rotateAllGameObjectsTransform = false;
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

    private List<GravityPosInTime> gravityPosInTimes;

    public bool IsUncontrolable { get; set; }

    //
    private Player player;

    //private PlayerAnimationControl playerAnimationControl;
    private PlayerState playerState;

    protected override void Awake()
    {
        base.Awake();

        allGameObjectsTransform = FindObjectOfType<AllGameObjectsTransform>();
        gravityControl = GetComponent<GravityControl>();
        gravityPosInTimes = new List<GravityPosInTime>();

        IsUncontrolable = false;

        //

        player = GetComponent<Player>();

        playerState = GetComponent<PlayerState>();

    }

    private void FixedUpdate()
    {
        if(!isMoving)
        {
            // IsRestricted
            playerState.PState = PLAYERSTATE.IDLE;

        }
    }

    public void OnPLayerMovementDirection(DIRECTION direction)
    {
        if (!isMoving)
        {
            currentPos = rb.position;

            IsRestricted = false;

            DirectionDecision(direction); // raycheck

            RaycastCheck(transform.forward, direction);

            // if another block or wall then return;

            Debug.Log("From PlayerMovements Stringcurrent: " + stringCurrent);

            if (IsRestricted)
            {
                // Define why is Restricted

                print("Restricted");
                return;
            }

            else
            {
                playerState.PState = PLAYERSTATE.RUNNING;
                player.OnRunning();

                ++movementCounts;
                // execute player move

                StartCoroutine("ExecutePlayerMovements");
            }

        }


        gameStatus.PlayerMovementCount(movementCounts);

    }


    IEnumerator ExecutePlayerMovements()
    {
        isMoving = true;
        float durationLimit = 0.5f;


        
        while (durationLimit >= 0f && Vector3.Distance(rb.position, targetPos) >= 0.05f)
        {

            durationLimit -= Time.deltaTime;

            //rb.MovePosition(Vector3.Lerp(rb.position, targetPos, movementSpeed * Time.deltaTime));
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, movementSpeed * Time.deltaTime));


            yield return null;
        }

        rb.MovePosition(targetPos);
        

        /*
        while (rb.position != targetPos)
        {
            rb.MovePosition(targetPos);
            yield return null;

        }
        */

        if (rotateAllGameObjectsTransform)
        {


            //allGameObjectsTransform.RotateTransform(gravityControl.GetGravityPos, gravityTransfer.gravityTransferPosition);
            //allGameObjectsTransform.RotateTransform(gravityControl.GetGravityPos);

            allGameObjectsTransform.RotateTransform(gravityControl.GravityPos, lastGravityPosition, gravityTransfer.gravityTransferPosition);



            rotateAllGameObjectsTransform = false;
        }


        isMoving = false;

        player.OffAllAnimations();

        //yield return null;//


        //print("Rotate");
        // rotate object
        //allGameObjectsTransform.RotateTransform(direction);


        // 만약 플레이어가 GT 에서 이동한거면
        // 
    }

    protected override void CollideWithBlock(RaycastHit hit, DIRECTION direction)
    {
        print(this.name + " Hit: " + hit.transform.name);


        blockArrays[(int)direction] = hit.collider.GetComponent<BlockMovement>();
        blockArrays[(int)direction].OnBlockMovementDirection(direction);
        blockArrays[(int)direction] = null;

    }

    protected override void CollideWithWall(RaycastHit hit)
    {
        IsRestricted = true;

        //playerState.PState = PLAYERSTATE.WALL_BLOCKED;
        //player.OnWallBlocked();
    }


    protected override void CollideWithGravityTransfer(RaycastHit hit, DIRECTION direction)
    {
        // raycheck from GT
        base.CollideWithGravityTransfer(hit, direction);

        lastGravityPosition = gravityControl.GravityPos;

        if (gravityTransfer.IsGoodToGo)
        {
            //test tele
            targetPos = rb.position + (transform.forward * movementDistance) + Vector3.down;
            targetPos = new Vector3(Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));

            //rb.position = targetPos;

            gravityTransfer.IsGoodToGo = false;

            //allGameObjectsTransform.RotateTransform(gravityControl.GetGravityPos);

            rotateAllGameObjectsTransform = true;

        }
        else
        {
            IsRestricted = true;

        }

    }



    protected override void CollideWithGoal(RaycastHit hit)
    {
        //base.CollideWithGoal(hit);

        IsRestricted = true;

    }


    public void RecordGravityPos()
    {
        gravityPosInTimes.Insert(0, new GravityPosInTime((int)gravityControl.GravityPos));

    }

    public void RewindGravityPos()
    {
        if(gravityPosInTimes.Count > 0)
        {
            GravityPosInTime points = gravityPosInTimes[0];

            allGameObjectsTransform.InstanteRotation((GRAVITYPOSITION)points.gravityPos);

            gravityPosInTimes.RemoveAt(0);
        }
    }




}