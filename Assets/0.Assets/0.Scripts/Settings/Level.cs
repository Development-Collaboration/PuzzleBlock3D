using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;


[Flags]
public enum LEVEL_TYPE
{

    /*
    None = 0,
    Human = 1 << 0,
    Flyer = 1 << 1,
    Machine = 1 << 2,
    Fish = 1 << 3,
    TEST = 1 << 4,
    All = int.MaxValue,    // ~0 으로 해도 같음
    */


    /*
    NO_ELIM_BLOCK,
    LIMIT_MOVEMENT,
    TIME_ATTACK,
    ELIM_BLOCK_NORMAL,
    */
}



public class Level : MonoBehaviour
{
    

    [SerializeField]
    private LEVEL_TYPE level_Type;
    
    // Cached Reference
    SceneLoader sceneLoader;
    private GameStatus gameStatus;

    // Params 
    private int blockCounts;

    [SerializeField]
    private int minGoalReach = 0;

    public int BlockCounts { get { return blockCounts; } }


    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start()
    {
        
    }

    public void CountBlocks()
    {
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
