using System;
using UnityEngine;


[Flags]
public enum BLOCK_TYPE
{
    //None = 0, 
    BreakOnGoal = 1 << 0,
    Unbreakable = 1 << 1,
    BreakOnMove = 1 << 2,
}

//
[RequireComponent(typeof(BlockMovement))]
[RequireComponent(typeof(GravityControl))]

public class Block : MonoBehaviour
{
    private BlockMovement blockMovement;
    private Level level;

    [SerializeField] private BLOCK_TYPE blockType;

    public BLOCK_TYPE BlockType { get; set; }

    [SerializeField] private int breakCount = 1;

    /*
    private int amountBreakableBlock = 0;
    private int amountUnBreakableBlock = 0;
    private int amountBreakOnMoveBlock = 0;
    */


    private void Awake()
    {
        blockMovement = GetComponent<BlockMovement>();
        level = FindObjectOfType<Level>();

    }

    private void Start()
    {

        CountBlocks();
        
    }


    private void CountBlocks()
    {

        level.CountBlocks(blockType);


    }

    public void BlockReachedGoal(Goal goal)
    {

        goal.OnBlockReachedGoal();

        /*
        switch (blockType)
        {
            case BLOCK_TYPE.Breakable:

                break;
            case BLOCK_TYPE.UnBreakable:

                break;
            case BLOCK_TYPE.BreakOnMove:

                break;

        }
        */
        //
        //level.GoalInBlock();

        //Destroy(this.gameObject);
    }


}
