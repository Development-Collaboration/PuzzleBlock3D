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

//



public class Player : MonoBehaviour
{
    private PlayerAnimationControl playerAnimationControl;

    private PlayerState playerState;
    private PlayerMovement playerMovement;

    private CameraControl cameraControl;

    //
 
    

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
        print("Playerstate: " + playerState.PState);

    }

    public void SetPlayer(PLAYERSTATE ps)
    {
        playerState.PState = ps;
        playerAnimationControl.PlayAnimation(ps);

        // Audio


    }

    public void OffAllAnimations()
    {
        playerAnimationControl.OffAllAnimations();
    }



    public void OnGravityTransfer()
    {

        cameraControl.InstantFollowPlayer();
    }


    public void OnEndGravityTransfer()
    {
        cameraControl.StartCamSetting();
    }



}
