using UnityEngine;

public class PlayerMovement : BasicMovement
{
    private BlockMovement[] blockArrays = new BlockMovement[4];


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

        blockArrays[(int)direction] = hit.collider.GetComponent<BlockMovement>();

        //                
        blockArrays[(int)direction].OnBlockMovementDirection(direction);

        //
        blockArrays[(int)direction] = null;
    }

    protected override void CollideWithGoal(RaycastHit hit)
    {
        //base.CollideWithGoal(hit);

        IsRestricted = true;

    }
}