
using UnityEngine;

public enum PLAYERSTATE
{
    IDLE,
    IDLE_PUSHING_BLOCK,
    RUNNING,
    PUSHING_BLOCK,
    GRAVITY_TURN,
    WALL_RESTRICTED,
    BLOCK_RESTRICTED,
    STAND_UP,
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
