using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;


[Flags]
public enum LEVEL_TYPE
{
    None = 0,
    TimeLimit = 1 << 0,
    MovementLimit = 1 << 1,
    BlockOnGoal= 1 << 2,
    BlockElimination = 1 << 3,
    BlockDestroyGoal = 1 << 4,

    All = int.MaxValue,    // ~0 으로 해도 같음
}

public class Level : MonoBehaviour
{
    [SerializeField] private LEVEL_TYPE levelType;

    // Cached Reference
    private SceneLoader sceneLoader;
    private GameStatus gameStatus;

    // Params
    private int blockCounts;
    public int BlockCounts { get { return blockCounts; } }

    private int breakableBlockCounts = 0;
    private int unBreakableBlockCounts = 0;
    private int breakOnMoveBlockCounts = 0;



    [SerializeField] private int minGoalReach = 0;


    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start()
    {

        SetLevelType();

    }

    private void SetLevelType()
    {

        print("LevelType: " + levelType);

        switch (levelType)
        {
            case LEVEL_TYPE.TimeLimit:
                break;
            case LEVEL_TYPE.MovementLimit:

                break;

            case LEVEL_TYPE.TimeLimit | LEVEL_TYPE.MovementLimit:

                break;

            case LEVEL_TYPE.BlockElimination:

                break;

            case LEVEL_TYPE.BlockOnGoal:

                break;
            case LEVEL_TYPE.BlockDestroyGoal:

                break;
        }


        /*
        if( (levelType & LEVEL_TYPE.TimeLimit)  != 0 )
        {
            print("Yes");
        }
        else
        {
            print("NO");
        }
        */


    }

    public void CountBlocks(BLOCK_TYPE blockType)
    {
        switch (blockType)
        {
            case BLOCK_TYPE.BreakOnGoal:
                ++breakableBlockCounts;
                break;
            case BLOCK_TYPE.Unbreakable:
                ++unBreakableBlockCounts;
                break;
            case BLOCK_TYPE.BreakOnMove:
                ++breakOnMoveBlockCounts;
                break;

        }

        ++blockCounts;
        CurrentAmountBlock();
    }

    public void CurrentAmountBlock()
    {
        if(null != gameStatus)
        {
            gameStatus.AmountBlockLeft(blockCounts);

        }
    }


    public void GoalInBlock()
    {
        --blockCounts;

        CurrentAmountBlock();

        if (blockCounts <= minGoalReach)
        {
            //
            sceneLoader.LoadNextScene();
        }
    }


    //

    public void RestartLevel()
    {
        sceneLoader.RestartScene();
    }




}
