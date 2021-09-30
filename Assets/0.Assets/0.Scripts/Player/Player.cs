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
    //private PlayerMovement playerMovement;

    //[SerializeField] CameraControl cameraControl;

    private CameraControl cameraControl;

    private void Awake()
    {
        playerAnimationControl = GetComponent<PlayerAnimationControl>();
        playerState = GetComponent<PlayerState>();

        //playerMovement = GetComponent<PlayerMovement>();

        cameraControl = FindObjectOfType<CameraControl>();


    }

    private void FixedUpdate()
    {

        switch(playerState.PState)
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

       // print("PLAYERSTATE: " + playerState.PState);



    }

    public void OnIdle()
    {
        playerAnimationControl.OnIdle();

    }



    public void OnRunning()
    {
        playerAnimationControl.OnRunning();

    }


    public void OnWallBlocked()
    {
        
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
