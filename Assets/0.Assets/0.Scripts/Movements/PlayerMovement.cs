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

    private CinemachineShake cinemachineShake;

    private float defaultMovementSpeed = 0f;
    private float newMovementSpeed = 0f;
    private float blockMovementSpeed = 0f;

    private List<GravityPosInTime> gravityPosInTimes;

    public bool IsUncontrolable { get; set; }

    //
    private Player player;

    //private PlayerAnimationControl playerAnimationControl;
    private PlayerState playerState;

    /*
    [SerializeField] [Tooltip("Add from movementSpeed")]
    private float movementSpeedExtra = 2f;
    */

    public float time;


    protected override void Awake()
    {
        base.Awake();

        allGameObjectsTransform = FindObjectOfType<AllGameObjectsTransform>();
        gravityControl = GetComponent<GravityControl>();
        gravityPosInTimes = new List<GravityPosInTime>();

        player = GetComponent<Player>();
        playerState = GetComponent<PlayerState>();

        cinemachineShake = FindObjectOfType<CinemachineShake>();

        IsUncontrolable = false;

        //



        IsRestricted = false;
    }

    private void Start()
    {
        defaultMovementSpeed = movementSpeed;

    }

    private void FixedUpdate()
    {
        
        if(!IsMoving)
        {
            player.SetPlayer(PLAYERSTATE.IDLE);           

        }


        // Rotation Fix + test
        if (Input.GetKeyDown(KeyCode.B))
        {
            print(gravityControl.GravityPos);
            allGameObjectsTransform.RotateTransform(gravityControl.GravityPos, lastGravityPosition, gravityTransfer.gravityTransferPosition);

        }


    }

    public void OnPLayerMovementDirection(DIRECTION direction)
    {
        if (!IsMoving)
        {
            currentPos = rb.position;

            //IsRestricted = false;

            // When last move was denied
            if(IsRestricted)
            {
                player.SetPlayer(PLAYERSTATE.STAND_UP);

                IsRestricted = false;
                return;
            }

            //
            DirectionDecision(direction); // raycheck
            RaycastCheck(transform.forward, direction);

            // if another block or wall then return;
            Debug.Log("From PlayerMovements Stringcurrent: " + stringCurrent);

            if (IsRestricted)
            {
                // Define why is Restricted
                print("Restricted");

                //cinemachineShake.ShakeCamera(4f, 0.1f);
                cinemachineShake.ShakeCamera();

                switch (stringCurrent)
                {
                    case stringBlock:
                        {
                            print("P: Restricted Block");
                            //player.OnBlockRestricted();
                            player.SetPlayer(PLAYERSTATE.BLOCK_RESTRICTED);

                        }
                        break;
                    case stringWall:
                        {
                            print("P: Restricted Wall");
                            // change animation later;
                            //player.OnWall();
                            player.SetPlayer(PLAYERSTATE.WALL_RESTRICTED);

                        }
                        break;

                    case stringGoal:
                        {
                            print("P: Restricted Goal");
                            // change animation later;
                            //player.OnWall();
                            player.SetPlayer(PLAYERSTATE.GOAL_RESTRICTED);

                        }
                        break;

                }
                


                return;
            }
            else
            {
                ++movementCounts;

                switch (stringCurrent)
                {
                    case stringNothing:
                        {
                            player.SetPlayer(PLAYERSTATE.RUNNING);
                            StartCoroutine("ExecutePlayerMovements");

                        }
                        break;
                    case stringBlock:
                        {
                            player.SetPlayer(PLAYERSTATE.PUSHING_BLOCK);

                            print("block move s: " + blockMovementSpeed);

                            StartCoroutine("ExecutePlayerMovements_Block");

                            //movementSpeed = defaultMovementSpeed;

                            //print("movementSpeed s: " + movementSpeed);
                        }
                        break;
                    case stringGravityTransfer:
                        {

                            //cam ctrl
                            player.OnGravityTransfer();

                            StartCoroutine("ExecutePlayerMovements_GT");



                        }
                        break;

                    case stringGoal:
                        {
                            
                        }
                        break;

                        //////////////
                    default:
                        {
                            //player.OnRunning();
                            player.SetPlayer(PLAYERSTATE.RUNNING);

                            StartCoroutine("ExecutePlayerMovements");

                        }
                        break;

                }

                // execute player move
               // StartCoroutine("ExecutePlayerMovements");

            }

        }

        gameStatus.PlayerMovementCount(movementCounts);

    }

    IEnumerator ExecutePlayerMovements_GT()
    {
        IsMoving = true;
        float durationLimit = 0.5f;


        while (durationLimit >= 0f && rb.position != targetPos)
        {

            durationLimit -= Time.deltaTime;

            rb.MovePosition(targetPos);
            yield return null;
        }


        gameObject.transform.position = targetPos;

        yield return null;


        //IsMoving = false;

        player.OffAllAnimations();


        if (rotateAllGameObjectsTransform)
        {
            allGameObjectsTransform.RotateTransform(gravityControl.GravityPos, lastGravityPosition, gravityTransfer.gravityTransferPosition);
            // at RotateTransform() ->         player.OnEndGravityTransfer();

            rotateAllGameObjectsTransform = false;
            yield return null;

        }

        IsMoving = false;

    }

    IEnumerator ExecutePlayerMovements_Block()
    {
        IsMoving = true;
        float durationLimit = 2f;


        while (durationLimit >= 0f && Vector3.Distance(rb.position, targetPos) >= 0.05f)
        {
            print("PLAYERSTATE.PUSHING_BLOCK");


            durationLimit -= Time.deltaTime;

            //rb.MovePosition(Vector3.Lerp(rb.position, targetPos, movementSpeed * Time.deltaTime));
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, (blockMovementSpeed) * Time.deltaTime));

            //print("Dis: " + Vector3.Distance(rb.position, targetPos));
            //print(durationLimit);
            yield return null;
        }

        //gameObject.transform.position = targetPos;

        rb.MovePosition(targetPos);

        yield return null;

        print("OFF");

        IsMoving = false;

        player.OffAllAnimations();
    }

    IEnumerator ExecutePlayerMovements()
    {

        IsMoving = true;
        float durationLimit = 0.5f;


        while (durationLimit >= 0f && Vector3.Distance(rb.position, targetPos) >= 0.05f)
        {

            durationLimit -= Time.deltaTime;

            //rb.MovePosition(Vector3.Lerp(rb.position, targetPos, movementSpeed * Time.deltaTime));
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, (movementSpeed) * Time.deltaTime));

            yield return null;
        }

        gameObject.transform.position = targetPos;

        yield return null;


        IsMoving = false;

        player.OffAllAnimations();

        /*
        if(extraSpeed > 0)
        {
            playerState.PState = PLAYERSTATE.IDLE;

        }
        else if(extraSpeed == 0)
        {
            playerState.PState = PLAYERSTATE.IDLE_PUSHING_BLOCK;

        }
        */

        /*
        if (rotateAllGameObjectsTransform)
        {
            //print("from co ro start");

            // old
            //allGameObjectsTransform.RotateTransform(lastGravityPosition, gravityTransfer.gravityTransferPosition);
            //allGameObjectsTransform.RotateTransform(gravityControl.GetGravityPos);


            // new
            allGameObjectsTransform.RotateTransform(gravityControl.GravityPos, lastGravityPosition, gravityTransfer.gravityTransferPosition);

            rotateAllGameObjectsTransform = false;
        }
        */


    }


    #region Collide~

    protected override void CollideWithBlock(RaycastHit hit, DIRECTION direction)
    {
        //Debug.Log(this.name + " Hit: " + hit.transform.name);


        blockArrays[(int)direction] = hit.collider.GetComponent<BlockMovement>();
        blockArrays[(int)direction].OnBlockMovementDirection(direction);
        //
        blockMovementSpeed = blockArrays[(int)direction].GetMovementSpeed;
        //
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

            //stringCurrent = stringGravityTransfer;

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

    #endregion

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



}