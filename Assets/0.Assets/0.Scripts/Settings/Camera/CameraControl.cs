using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine; 

public class CameraControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerCinemachineVirtualCamera;
    private CinemachineFramingTransposer cinemachineFramingTransposer;

    //[SerializeField] private PlayerMovement playerMovement;

    private float deadZoneWidth = 0;
    private float deadZoneHeight = 0;

    private float dampingX = 0;
    private float dampingY = 0;
    private float dampingZ = 0;


    private void Awake()
    {
        StartSetup();

    }


    private void StartSetup()
    {

        if(playerCinemachineVirtualCamera != null)
            playerCinemachineVirtualCamera.m_Follow = FindObjectOfType<Player>().transform;

        cinemachineFramingTransposer = playerCinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        


        deadZoneWidth = cinemachineFramingTransposer.m_DeadZoneWidth;
        deadZoneHeight = cinemachineFramingTransposer.m_DeadZoneHeight;

        dampingX = cinemachineFramingTransposer.m_XDamping;
        dampingY = cinemachineFramingTransposer.m_YDamping;
        dampingZ = cinemachineFramingTransposer.m_ZDamping;
    }

    private void SetAmountDampingDeadZone(float deadZoneW, float deadZoneH,  float damingX, float damingY, float damingZ)
    {
        cinemachineFramingTransposer.m_DeadZoneWidth = deadZoneW;
        cinemachineFramingTransposer.m_DeadZoneHeight = deadZoneH;

        cinemachineFramingTransposer.m_XDamping = damingX;
        cinemachineFramingTransposer.m_YDamping = damingY;
        cinemachineFramingTransposer.m_ZDamping = damingZ;
    }

    private void SetAmountDampingDeadZone(float deadZone, float daming)
    {
        cinemachineFramingTransposer.m_DeadZoneWidth = deadZone;
        cinemachineFramingTransposer.m_DeadZoneHeight = deadZone;

        cinemachineFramingTransposer.m_XDamping = daming;
        cinemachineFramingTransposer.m_YDamping = daming;
        cinemachineFramingTransposer.m_ZDamping = daming;
    }

    private void SetAmountDampingDeadZone()
    {
        cinemachineFramingTransposer.m_DeadZoneWidth = 0;
        cinemachineFramingTransposer.m_DeadZoneHeight = 0;

        cinemachineFramingTransposer.m_XDamping = 0;
        cinemachineFramingTransposer.m_YDamping = 0;
        cinemachineFramingTransposer.m_ZDamping = 0;
    }


    public void InstantFollowPlayer()
    {
        SetAmountDampingDeadZone();
    }

    public void StartCamSetting()
    {
        cinemachineFramingTransposer.m_DeadZoneWidth = deadZoneWidth;
        cinemachineFramingTransposer.m_DeadZoneHeight = deadZoneHeight;

        cinemachineFramingTransposer.m_XDamping = dampingX;
        cinemachineFramingTransposer.m_YDamping = dampingY;
        cinemachineFramingTransposer.m_ZDamping = dampingZ;

    }




}
