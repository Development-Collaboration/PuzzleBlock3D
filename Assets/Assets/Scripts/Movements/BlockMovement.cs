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

        MovementsControl (direction);

        gameStatus.BlockMovementCounts();
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

        IsRestricted = true;

        playerMovement.IsRestricted = true;
    }


    protected override void CollideWithGoal(RaycastHit hit)
    {
        //base.CollideWithGoal(hit);

        print("Block Reached Goal");

        
        block.GoalInBlock();
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

        }
        else
        {
            IsRestricted = true;
            playerMovement.IsRestricted = true;

        }

    }



}
