using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Cached Reference
    SceneLoader sceneLoader;


    // Params 
    [SerializeField] private int blocks;
    private int minGoalReach = 0;


    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void CountBlocks()
    {
        ++blocks;
    }

    public void GoalInBlock()
    {
        --blocks;

        if(blocks <= minGoalReach)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
