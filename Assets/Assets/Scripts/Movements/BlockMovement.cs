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

        print("from Block : Collide with GT");


        /*
        IsRestricted = true;

        playerMovement.IsRestricted = true;
        */
    }



}
