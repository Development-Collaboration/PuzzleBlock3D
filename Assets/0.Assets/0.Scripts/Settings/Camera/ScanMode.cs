using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class ScanMode : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera PlayerCinemachineVirtualCamera;
    //CinemachineFramingTransposer

    [SerializeField] private GameObject scanModeCanvas;

    //[SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField] private bool isScanModeOn = false;
    public bool IsScanModeOn { get { return isScanModeOn; } set { isScanModeOn = value; } }

    private TouchDetection touchDetection;

    private float startOrthgraphicSize;
    private float currentOrthgraphicSize;
    private float zoomOutSize;
    private float zoomInSize;

    private float zoomOutSizeMax;
    private float zoomInSizeMin = 5f;

    [SerializeField] private int zoomingAmount = 1;

    [SerializeField] private int zoomingSpeed = 10;



    private float targetZoomSize;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        touchDetection = FindObjectOfType<TouchDetection>();

        //cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();


        startOrthgraphicSize = PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize;

        currentOrthgraphicSize = startOrthgraphicSize;

        zoomOutSize = (currentOrthgraphicSize * 1.5f);

        zoomInSize = (currentOrthgraphicSize * 0.5f);

        zoomOutSizeMax = zoomOutSize + 5f;
        //zoomInSizeMin = ((zoomInSize - 5f) > 0) ? (zoomInSize - 5f) : 0;


        scanModeCanvas.SetActive(false);




    }



    public void OnScanMode()
    {
        
        if (!isScanModeOn)
        {

            scanModeCanvas.SetActive(true);

            playerMovement.IsUncontrolable = true;

            touchDetection.OnDisableControlButton();

        }
        else
        {
            scanModeCanvas.SetActive(false);



        }

        StartCoroutine("ZoomMode");

    }

    public void OnZoomingIn()
    {
        if(PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize > zoomInSizeMin)
        {
            targetZoomSize = PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize - zoomingAmount;

            StartCoroutine("ZoomIn");
        }

    }

    public void OnZoomingOut()
    {
        if (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize < zoomOutSizeMax)
        {
            targetZoomSize = PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize + zoomingAmount;

            StartCoroutine("ZoomOut");

        }

    }

    
    IEnumerator ZoomIn()
    {
        // Zoom In
        while (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize > targetZoomSize)
        {
            PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize -= zoomingSpeed * Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator ZoomOut()
    {
        // Zoom out
        while (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize < targetZoomSize)
        {
            PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize += zoomingSpeed * Time.deltaTime;

            yield return null;
        }
    }
    



    IEnumerator ZoomMode()
    {
        if (!isScanModeOn)
        {
            // Zoom out
            while (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize <= zoomOutSize)
            {
                PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize += zoomingSpeed * Time.deltaTime;

                yield return null;

            }

            currentOrthgraphicSize = PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize;

            isScanModeOn = true;

        }
        else
        {
            // return to OriginalSize
            if (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize < startOrthgraphicSize)
            {
                // Zoom out
                while (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize <= startOrthgraphicSize)
                {
                    PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize += zoomingSpeed * Time.deltaTime;

                    yield return null;
                }
            }
            else
            {

                // Zoom In
                while (PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize >= startOrthgraphicSize)
                {
                    PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize -= zoomingSpeed * Time.deltaTime;

                    yield return null;
                }
            }


            currentOrthgraphicSize = PlayerCinemachineVirtualCamera.m_Lens.OrthographicSize;

            isScanModeOn = false;

            playerMovement.IsUncontrolable = false;

            touchDetection.OnEnableControlButton();

        }


        /*
        if (!isScanModeOn)
        {

   
            isScanModeOn = true;

        }
        else
        {


            isScanModeOn = false;

        }
        */

        /*
        if (!isScanModeOn)
        {
            // Zoom out
            while (cinemachineVirtualCamera.m_Lens.OrthographicSize <= zoomOutSize)
            {
                cinemachineVirtualCamera.m_Lens.OrthographicSize += zoomingSpeed * Time.deltaTime;

                yield return null;

            }
            isScanModeOn = true;

        }
        else
        {

            // Zoom In
            while (cinemachineVirtualCamera.m_Lens.OrthographicSize >= startOrthgraphicSize)
            {
                cinemachineVirtualCamera.m_Lens.OrthographicSize -= zoomingSpeed * Time.deltaTime;

                yield return null;
            }

            isScanModeOn = false;

        }
       */

    }


}
