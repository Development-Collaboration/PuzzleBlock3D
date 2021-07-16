using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : BasicMovement
{
    private PlayerMovement playerMovement;


    protected override void Awake()
    {
        base.Awake();

        playerMovement = FindObjectOfType<PlayerMovement>();

    }

    public void OnBlockMovementDirection(DIRECTION direction)
    {
        base.MovementsControl(direction);
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

}
