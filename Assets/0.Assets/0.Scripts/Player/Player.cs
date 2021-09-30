using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

//
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

//
[RequireComponent(typeof(TouchDetection))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(GravityControl))]
[RequireComponent(typeof(PlayerAnimationControl))]
[RequireComponent(typeof(PlayerState))]




public class Player : MonoBehaviour
{
    private PlayerAnimationControl playerAnimationControl;

    private PlayerState playerState;
    private PlayerMovement playerMovement;

    //[SerializeField] CameraControl cameraControl;

    private CameraControl cameraControl;

    

    private void Awake()
    {
        //playerAnimationControl = GetComponent<PlayerAnimationControl>();
        //playerState = GetComponent<PlayerState>();

        playerMovement = GetComponent<PlayerMovement>();

        playerAnimationControl = FindObjectOfType<PlayerAnimationControl>();
        playerState = FindObjectOfType<PlayerState>();

        cameraControl = FindObjectOfType<CameraControl>();

        playerState.PState = PLAYERSTATE.BEGIN;

    }

    private void FixedUpdate()
    {
        print("Playerstate: " + playerState.PState);

        if(!(playerMovement.IsMoving))
        {
            switch (playerState.PState)
            {
                case PLAYERSTATE.IDLE:
                    {
                        OnIdle();
                    }
                    break;

                    /*
                case PLAYERSTATE.RUNNING:
                    {
                        OnRunning();
                    }
                    break;
                    */
            }
        }
        
        /*
        switch(playerState.PState)
        {
            case PLAYERSTATE.IDLE:
                {
                    OnIdle();
                }
                break;

                
            case PLAYERSTATE.RUNNING:
                {
                    OnRunning();
                }
                break;
                
        }
        */

       // print("PLAYERSTATE: " + playerState.PState);



    }

    private void Setting(PLAYERSTATE ps)
    {
        playerState.PState = ps;


    }

    public void OnIdle()
    {
        playerAnimationControl.OnIdle();

    }

    public void OnRunning()
    {
        Setting(PLAYERSTATE.RUNNING);
        playerAnimationControl.OnRunning();

    }

    public void OnPushingBlock()
    {
        Setting(PLAYERSTATE.PUSHING_BLOCK);
        playerAnimationControl.OnBlock();


    }
    public void OnBlockRestricted()
    {
        Setting(PLAYERSTATE.BLOCK_RESTRICTED);
        playerAnimationControl.OnBlockRestricted();

    }

    public void OnWall()
    {
        Setting(PLAYERSTATE.WALL_RESTRICTED);
        playerAnimationControl.OnWallRestriected();
        
    }

    public void OnStandUp()
    {
        Setting(PLAYERSTATE.STAND_UP);
        playerAnimationControl.OnStandUp();
    }

    public void OnGravityTransfer()
    {
        //playerState.PState = PLAYERSTATE.RUNNING;
        //playerAnimationControl.OnGravityTransfer();

        cameraControl.InstantFollowPlayer();
    }


    public void OnEndGravityTransfer()
    {


        cameraControl.StartCamSetting();
    }


    public void OffAllAnimations()
    {
        playerAnimationControl.OffAllAnimations();
    }

}
