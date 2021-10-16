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
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimationControl = GetComponent<PlayerAnimationControl>();
        playerState = GetComponent<PlayerState>();

        cameraControl = FindObjectOfType<CameraControl>();


        playerState.PState = PLAYERSTATE.BEGIN;

    }

    private void FixedUpdate()
    {
        //print("Playerstate: " + playerState.PState);

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

    public void SetPlayer(PLAYERSTATE ps)
    {
        playerState.PState = ps;
        playerAnimationControl.PlayAnimation(ps);

        // Audio


    }

    public void OnIdle()
    {
        playerAnimationControl.OnIdle();

    }
    /*
    public void OnRunning()
    {
        SetPlayer(PLAYERSTATE.RUNNING);
        playerAnimationControl.OnRunning();

    }

    public void OnPushingBlock()
    {
        SetPlayer(PLAYERSTATE.PUSHING_BLOCK);
        playerAnimationControl.OnBlock();


    }
    public void OnBlockRestricted()
    {
        SetPlayer(PLAYERSTATE.BLOCK_RESTRICTED);
        playerAnimationControl.OnBlockRestricted();

    }

    public void OnWall()
    {
        SetPlayer(PLAYERSTATE.WALL_RESTRICTED);
        playerAnimationControl.OnWallRestriected();
        
    }

    public void OnStandUp()
    {
        SetPlayer(PLAYERSTATE.STAND_UP);
        playerAnimationControl.OnStandUp();
    }
    */

    public void OffAllAnimations()
    {
        playerAnimationControl.OffAllAnimations();
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



}
