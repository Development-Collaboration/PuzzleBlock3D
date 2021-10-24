using System;
using UnityEngine;

//
/*
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
*/

public enum BLOCK_TYPE
{
    NORMAL,
    BREAK_MOVE,
    UNBREAKABLE
}

[Serializable]
public struct Block_Attributes
{
    public BLOCK_TYPE blockType;
    
}


[RequireComponent(typeof(BlockMovement))]
[RequireComponent(typeof(GravityControl))]


public class Block : MonoBehaviour
{
    private BlockMovement blockMovement;
    private Level level;


    // 추후 Hide it
    [SerializeField]
    private Block_Attributes Block_Attributes;


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
        level.CountBlocks();
    }

    public void BlockReachedGoal(Goal goal)
    {
        goal.OnBlockReachedGoal();

        //level.GoalInBlock();



        //Destroy(this.gameObject);
    }


}
