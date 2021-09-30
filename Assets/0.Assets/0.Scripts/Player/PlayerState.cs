
using UnityEngine;

public enum PLAYERSTATE
{
    IDLE,
    RUNNING,
    PUSHING_BLOCK,
    GRAVITY_TURN,
    WALL_BLOCKED,
    GOAL,
    BEGIN

}

public class PlayerState : MonoBehaviour
{
    public PLAYERSTATE PState { get; set; }
    public PLAYERSTATE PLastState { get; set; }

    /*
    private void Awake()
    {
        PState = PLAYERSTATE.BEGIN;
    }
    */
    /*
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            print("(PlayerState Return Pressed) PLAYERSTATE: " + PState);
        }
    }
    */

}
