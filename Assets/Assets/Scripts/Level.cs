using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Cached Reference
    SceneLoader sceneLoader;
    private GameStatus gameStatus;

    // Params 
    private int blockCounts;
    private int minGoalReach = 0;

    public int BlockCounts { get { return blockCounts; } }


    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
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
            sceneLoader.LoadNextScene();
        }
    }


    //

    public void RestartLevel()
    {
        sceneLoader.RestartScene();
    }
}
