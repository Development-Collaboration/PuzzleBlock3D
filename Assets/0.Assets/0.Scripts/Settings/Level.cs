 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LEVEL_TYPE
{
    NO_ELIM_BLOCK,
    LIMIT_MOVEMENT,
    TIME_ATTACK,
    ELIM_BLOCK_NORMAL,

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
