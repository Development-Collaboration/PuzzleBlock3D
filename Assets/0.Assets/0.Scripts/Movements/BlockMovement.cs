using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BlockMovement : BasicMovement
{
    private PlayerMovement playerMovement;
    private Block block;


    protected override void Awake()
    {
        base.Awake();

        playerMovement = FindObjectOfType<PlayerMovement>();

        //block = FindObjectOfType<Block>();

        block = GetComponent<Block>();
       
    }

    public void OnBlockMovementDirection(DIRECTION direction)
    {

        //MovementsControl (direction);

        if ((!IsMoving))
        {
            currentPos = rb.position;

            IsRestricted = false;
            DirectionDecision(direction); // raycheck

            RaycastCheck(transform.forward, direction);


            Debug.Log("From BlockMovement Stringcurrent: " + stringCurrent);


            // if another block or wall then return;
            if (IsRestricted)
            {


                print("Restricted");

                // I dont think it's neccessary
                //targetPos = currentPos;
                return;
            }

            else
            {
                ++movementCounts;


                StartCoroutine("ExecuteBlockMovements");
            }



        }

        gameStatus.BlockMovementCounts();
    }


    IEnumerator ExecuteBlockMovements()
    {

        IsMoving = true;

        //print(this.name);

        //float durationLimit = 0.5f;
        float durationLimit = 2f;


        while (durationLimit >= 0f && Vector3.Distance(rb.position, targetPos) >= 0.05f)
        {

            durationLimit -= Time.deltaTime;

            //rb.MovePosition(Vector3.Lerp(rb.position, targetPos, movementSpeed * Time.deltaTime));
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, movementSpeed * Time.deltaTime));


            yield return null;
        }



        rb.MovePosition(targetPos);

        IsMoving = false;



    }

    protected override void CollideWithWall(RaycastHit hit)
    {
        print("from Block : Wall Dectected");

        IsRestricted = true;

        playerMovement.IsRestricted = true;
    }

    protected override void CollideWithBlock(RaycastHit hit, DIRECTION direction)
    {

        print("from Block : another block on that direction Dectected");

        stringCurrent = stringRestriectedBlock;
        
        IsRestricted = true;

        playerMovement.IsRestricted = true;
    }


    protected override void CollideWithGravityTransfer(RaycastHit hit, DIRECTION direction)
    {
        print("Block Reached CollideWithGravityTransfer");


        // raycheck from GT
        base.CollideWithGravityTransfer(hit, direction);


        if (gravityTransfer.IsGoodToGo)
        {
            //test tele
            targetPos = rb.position + (transform.forward * movementDistance) + Vector3.down;
            targetPos = new Vector3(Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y), Mathf.RoundToInt(targetPos.z));

            //rb.position = targetPos;

            gravityTransfer.IsGoodToGo = false;

        }
        else
        {
            IsRestricted = true;
            playerMovement.IsRestricted = true;

        }

    }

    protected override void CollideWithGoal(RaycastHit hit)
    {
        //base.CollideWithGoal(hit);

        print("Block Reached Goal");

        block.BlockReachedGoal(hit.collider.GetComponent<Goal>());
    }

    protected override void CollideWithGoalTransparent(RaycastHit hit)
    {
        //base.CollideWithGoalTransparent(hit);

        print("Block Reached GoalTransparent");


    }



}
