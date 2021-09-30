using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameObjectsTransform : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private Player player;

    private Vector3[] allGameObjectsEdgeArrays = new Vector3[6];

    private TouchDetection touchDetection;

    [SerializeField] private float rotationSpeed = 1.5f;

    private Quaternion targetRotation;
    private Quaternion lastRotation;


    public bool isRotating { get; set; }


    private float x = 0;
    private float y = 0;
    private float z = 0;

    private void Awake()
    {
        allGameObjectsEdgeArrays[0] = new Vector3(0, 0, 0);  // UP
        allGameObjectsEdgeArrays[1] = new Vector3(-90, 0, 0);  // UL Front
        allGameObjectsEdgeArrays[2] = new Vector3(-180, 0, 0); // DOWN
        allGameObjectsEdgeArrays[3] = new Vector3(90, 0, 0); // DR  BACK
        allGameObjectsEdgeArrays[4] = new Vector3(0, 0, 90); // UR RIGHT
        allGameObjectsEdgeArrays[5] = new Vector3(0, 0, -90); // DL LEFT

        isRotating = false;

        playerMovement = FindObjectOfType<PlayerMovement>();

        touchDetection = FindObjectOfType<TouchDetection>();

        player = FindObjectOfType<Player>();

    }

    public void InstanteRotation(GRAVITYPOSITION gravityPosition)
    {
        print("InstanteRotation");


        switch (gravityPosition)
        {
            case GRAVITYPOSITION.UP:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[0]);
                break;

            case GRAVITYPOSITION.UL:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[1]);
                break;

            case GRAVITYPOSITION.DOWN:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[2]);
                break;

            case GRAVITYPOSITION.DR:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[3]);
                break;

            case GRAVITYPOSITION.UR:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[4]);
                break;

            case GRAVITYPOSITION.DL:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[5]);
                break;
        }

        transform.rotation = targetRotation;

    }

    public void CurrentGravityPosition(GRAVITYPOSITION gravityPosition)
    {

        switch (gravityPosition)
        {
            case GRAVITYPOSITION.UP:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[0]);
                break;

            case GRAVITYPOSITION.UL:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[1]);
                break;

            case GRAVITYPOSITION.DOWN:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[2]);
                break;

            case GRAVITYPOSITION.DR:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[3]);
                break;

            case GRAVITYPOSITION.UR:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[4]);
                break;

            case GRAVITYPOSITION.DL:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[5]);
                break;
        }


    }


    #region DecideTargetRotation_

    private void DecideTargetRotation_UP(GravityTransferPosition gravityTransferPosition, GRAVITYPOSITION gravityPosition)
    {

        if (Quaternion.Euler(new Vector3(0, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, 0));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 0, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 90, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, 90));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, -90));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 90, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, -180));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 180, 0));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 180, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, 270));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, 90));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 270, -90));
                    break;
            }
        }
        ///////////////////
        ///
        else if (Quaternion.Euler(new Vector3(180, 0, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 270));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 0, 180));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 180));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180f, 0, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 90, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 270));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, 90));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, 90));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 180, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 270));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, 180));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 180, 180));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 270, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180f, 270, 270));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 360, 90));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 360, 270));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180f, 270, 90));
                    break;
            }
        }

        else
        {
            CurrentGravityPosition(gravityPosition);
        }

    }

    private void DecideTargetRotation_UR(GravityTransferPosition gravityTransferPosition, GRAVITYPOSITION gravityPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 90));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 90, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 180));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 90));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 180, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 360, 0));
                    break;
            }
        }
        //////
        ///
        else if (Quaternion.Euler(new Vector3(180, 0, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 360));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 270));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(270, 0, 270));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 90, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 360));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(270, 0, 360));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 180, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 360));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 270));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, 270));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 270, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 270, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 270, 360));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 360));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(270, 360, 180));
                    break;
            }
        }
        else
        {
            CurrentGravityPosition(gravityPosition);
        }

    }

    private void DecideTargetRotation_DR(GravityTransferPosition gravityTransferPosition, GRAVITYPOSITION gravityPosition)
    {
        if (Quaternion.Euler(new Vector3(90, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));

                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 0));

                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, -90));

                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(90, 0, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -90));
                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, -90));
                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(90, 0, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -180));
                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, -270));
                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -180));
                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(90, 0, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, -360));
                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -270));
                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -180));
                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -270));
                    break;
            }
        }

        //////
        ///
        else if (Quaternion.Euler(new Vector3(90, 180, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 90));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -90));
                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(90, 180, -90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, -90));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(90, 180, -180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, -180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, -180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(90, 180, -270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -360));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, -270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, -180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, -270));
                    break;
            }
        }

        else
        {
            CurrentGravityPosition(gravityPosition);
        }
    }

    private void DecideTargetRotation_DL(GravityTransferPosition gravityTransferPosition, GRAVITYPOSITION gravityPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, -90));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 90,270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, -180));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, -90));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 180, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 0));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 360, -180));
                    break;
            }
        }

        //
        else if (Quaternion.Euler(new Vector3(180, 0, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 90));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(270, 0, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 90, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(270, 0, 180));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 180, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 90));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(180, 270, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 270, 180));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 180));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 270, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(270, 360, 0));
                    break;
            }
        }
        else
        {
            CurrentGravityPosition(gravityPosition);
        }
    }

    private void DecideTargetRotation_UL(GravityTransferPosition gravityTransferPosition, GRAVITYPOSITION gravityPosition)
    {
        if (Quaternion.Euler(new Vector3(-90, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-180f, 0, 0));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 0, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 0, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 0, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 0, 180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 270));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 0, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 360));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 0, 270));
                    break;
            }
        }

        //
        else if (Quaternion.Euler(new Vector3(-90, 180, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-180f, 180, 0));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 180, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 180, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 180, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 180, 180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 270));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 180, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 360));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 270));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 180, 270));
                    break;
            }
        }
        else
        {
            CurrentGravityPosition(gravityPosition);
        }

    }

    private void DecideTargetRotation_DOWN(GravityTransferPosition gravityTransferPosition, GRAVITYPOSITION gravityPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 180));
                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(0, 90, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 90));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 270));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 180, 180));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 270));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 360, 90));
                    break;
            }
        }

        //

        else if (Quaternion.Euler(new Vector3(180, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 90));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 0, 0));
                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(180, 90, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, 90));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 90));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 90, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, -90));
                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(180, 180, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, 90));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 180, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, 0));
                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(180, 270, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(180, 270, 90));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 90));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(180, 270, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(270, 180, 90));
                    break;
            }

        }
        else
        {
            CurrentGravityPosition(gravityPosition);
        }
    }

    #endregion

    /*
    #region DecideTargetRotation_

    private void DecideTargetRotation_UP(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, 0));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 0, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 90, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, 90));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, -90));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 90, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, -180));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 180, 0));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 180, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 90));
                    break;

                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-90f, 0, 270));
                    break;
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(90f, 0, 90));
                    break;
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0f, 270, -90));
                    break;
            }
        }
    }

    private void DecideTargetRotation_UR(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 90));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 90, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 180));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 90));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 180, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 180));
                    break;
                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 360, 0));
                    break;
            }
        }
    }

    private void DecideTargetRotation_DR(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(90, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));

                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, 0));

                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, -90));

                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(90, 0, -90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -90));
                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, -90));
                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(90, 0, -180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -180));
                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, -270));
                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -180));
                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(90, 0, -270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TB:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, -360));
                    break;

                case GravityTransferPosition.R:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -270));
                    break;

                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -180));
                    break;

                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(180, 0, -270));
                    break;
            }
        }
    }

    private void DecideTargetRotation_DL(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, -90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, -90));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 90, -90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, -180));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, -90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, -90));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 180, -90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 2700, -90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                case GravityTransferPosition.L:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 0));
                    break;
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, -180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 360, -180));
                    break;
            }
        }
    }

    private void DecideTargetRotation_UL(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(-90, 0, 0)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, -90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-180f, 0, 0));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 90));
                    break;  
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 0, 90)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 0, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 0, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 0, 180));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 270));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(-90, 0, 270)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.TF:
                    targetRotation = Quaternion.Euler(new Vector3(0, -90, 360));
                    break;
                case GravityTransferPosition.FL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 180));
                    break;
                case GravityTransferPosition.FR:
                    targetRotation = Quaternion.Euler(new Vector3(-180, 0, 270));
                    break;
            }
        }
    }

    private void DecideTargetRotation_DOWN(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(0, 0, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 180));
                    break;
            }

        }
        else if (Quaternion.Euler(new Vector3(0, 90, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 0, 90));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 90, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 0, 270));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 180, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 180, 180));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 180, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 180, 180));
                    break;
            }
        }
        else if (Quaternion.Euler(new Vector3(0, 270, 180)) == transform.rotation)
        {
            switch (gravityTransferPosition)
            {
                case GravityTransferPosition.BL:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 270));
                    break;
                case GravityTransferPosition.BB:
                    targetRotation = Quaternion.Euler(new Vector3(90, 360, 270));
                    break;
                case GravityTransferPosition.BR:
                    targetRotation = Quaternion.Euler(new Vector3(0, 270, 90));
                    break;
                case GravityTransferPosition.BF:
                    targetRotation = Quaternion.Euler(new Vector3(-90, 360, 90));
                    break;
            }
        }
    }

    
    private void DecideTargetRotation_(GravityTransferPosition gravityTransferPosition)
    {
        if (Quaternion.Euler(new Vector3(90, 0, 0)) == transform.rotation)
        {

        }
        else if (Quaternion.Euler(new Vector3(90, 0, -90)) == transform.rotation)
        {
        }
        else if (Quaternion.Euler(new Vector3(90, 0, -180)) == transform.rotation)
        {
        }
        else if (Quaternion.Euler(new Vector3(90, 0, -270)) == transform.rotation)
        {
        }
    }
    

    #endregion
    */



    public void RotateTransform(GRAVITYPOSITION gravityPosition, GRAVITYPOSITION lastGravityPosition, GravityTransferPosition gravityTransferPosition)
    {
        /*
        print(" new !!!!!rotate");
        print("gravityPosition: " + gravityPosition);
        print("lastGravityPosition: " + lastGravityPosition);
        print("gravityTransferPosition: " + gravityTransferPosition);
        */


        switch (lastGravityPosition)
        {           
            case GRAVITYPOSITION.UP:
                {
                    DecideTargetRotation_UP(gravityTransferPosition, gravityPosition);
                    break;
                }

            case GRAVITYPOSITION.UR:
                {

                    DecideTargetRotation_UR(gravityTransferPosition, gravityPosition);

                    break;
                }

            case GRAVITYPOSITION.DR:
                {
                    DecideTargetRotation_DR(gravityTransferPosition, gravityPosition);
                    break;
                }


            case GRAVITYPOSITION.DL:
                {
                    DecideTargetRotation_DL(gravityTransferPosition, gravityPosition);
                    break;
                }


            case GRAVITYPOSITION.UL:
                {
                    DecideTargetRotation_UL(gravityTransferPosition, gravityPosition);
                    break;
                }

            case GRAVITYPOSITION.DOWN:
                { 
                    DecideTargetRotation_DOWN(gravityTransferPosition, gravityPosition);
                    break;
                }
        }


        StartCoroutine("Rotate");



    }

    // Old
    public void RotateTransform(GRAVITYPOSITION lastGravityPosition, GravityTransferPosition gravityTransferPosition)
    {

        print("rotate");

        
        switch (lastGravityPosition)
        {
            case GRAVITYPOSITION.UP:
                {
                    switch(gravityTransferPosition)
                    {
                        case GravityTransferPosition.TF:
                            targetRotation = Quaternion.Euler(new Vector3(-90f, 0,0));

                            break;

                        case GravityTransferPosition.TR:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0, 90));

                            break;

                        case GravityTransferPosition.TB:
                            targetRotation = Quaternion.Euler(new Vector3(90f, 0, 0));

                            break;

                        case GravityTransferPosition.TL:
                            targetRotation = Quaternion.Euler(new Vector3(0f, 0, -90));

                            break;                     
                                    
                    }
                    break;

                }

            case GRAVITYPOSITION.UL:
                {
                    switch (gravityTransferPosition)
                    {
                        case GravityTransferPosition.BF:
                            targetRotation = Quaternion.Euler(new Vector3(-180f, 0, 0));

                            break;

                        case GravityTransferPosition.FR:
                            targetRotation = Quaternion.Euler(new Vector3(0, -90, 90));

                            break;

                        case GravityTransferPosition.TF:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                            break;

                        case GravityTransferPosition.FL:
                            targetRotation = Quaternion.Euler(new Vector3(90f, 0, 90));

                            break;

                    }
                    break;
                }

            case GRAVITYPOSITION.DOWN:
                {
                    switch (gravityTransferPosition)
                    {
                        case GravityTransferPosition.BB:
                            targetRotation = Quaternion.Euler(new Vector3(90, 0, 0));

                            break;

                        case GravityTransferPosition.BR:
                            targetRotation = Quaternion.Euler(new Vector3(-1800, 0, -90));

                            break;

                        case GravityTransferPosition.BF:
                            targetRotation = Quaternion.Euler(new Vector3(-90, 0, 0));

                            break;

                        case GravityTransferPosition.BL:
                            targetRotation = Quaternion.Euler(new Vector3(-180, 0, 90));

                            break;

                    }
                    break;
                }

            case GRAVITYPOSITION.DR:
                {
                    switch (gravityTransferPosition)
                    {
                        case GravityTransferPosition.TB:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                            break;

                        case GravityTransferPosition.R:
                            targetRotation = Quaternion.Euler(new Vector3(0, 90,90));

                            break;

                        case GravityTransferPosition.BB:
                            targetRotation = Quaternion.Euler(new Vector3(-180, 0, 0));

                            break;

                        case GravityTransferPosition.L:
                            targetRotation = Quaternion.Euler(new Vector3(0, -90, -90));

                            break;

                    }
                    break;
                }

            case GRAVITYPOSITION.UR:
                {
                    switch (gravityTransferPosition)
                    {
                        case GravityTransferPosition.FR:
                            targetRotation = Quaternion.Euler(new Vector3(-90, 0, 90));

                            break;

                        case GravityTransferPosition.BR:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0, 180));

                            break;

                        case GravityTransferPosition.R:
                            targetRotation = Quaternion.Euler(new Vector3(90, 0, 90));

                            break;

                        case GravityTransferPosition.TR:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0,0));

                            break;

                    }
                    break;
                }

            case GRAVITYPOSITION.DL:
                {
                    switch (gravityTransferPosition)
                    {
                        case GravityTransferPosition.FL:
                            targetRotation = Quaternion.Euler(new Vector3(-90, 0, -90));

                            break;

                        case GravityTransferPosition.TL:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                            break;

                        case GravityTransferPosition.L:
                            targetRotation = Quaternion.Euler(new Vector3(90, 0, -90));

                            break;

                        case GravityTransferPosition.BL:
                            targetRotation = Quaternion.Euler(new Vector3(0, 0, -180));

                            break;

                    }
                    break;
                }


        }

        StartCoroutine("Rotate");
        
    }
    

    /*
    public void RotateTransform(GravityPosition gravityPosition)
    {
        print("rotate");

        switch (gravityPosition)
        {
            case GravityPosition.UP:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[0]);
                break;

            case GravityPosition.UL:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[1]);
                break;

            case GravityPosition.DOWN:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[2]);
                break;

            case GravityPosition.DR:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[3]);
                break;

            case GravityPosition.UR:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[4]);
                break;

            case GravityPosition.DL:
                targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[5]);
                break;
        }

        StartCoroutine("Rotate");

    }
    */


    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.W))
        {

            x -= 90f;
            targetRotation = Quaternion.Euler(new Vector3(x,y,z));
            StartCoroutine("Rotate");

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            x += 90f;
            targetRotation = Quaternion.Euler(new Vector3(x, y, z));
            StartCoroutine("Rotate");

        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A");

            
            if ((-95 < x && x < -85))
            {
                print("여기");

                x = 0f;
                y = 90f;
                z = -90f;


                print("x,y,z: " + x + "," + "." + y + "," + z);

            }
            /*
            else if ( (x > -5 && x < 5 )|| (x > -185 && x < -175))
            {
                z -= 90f;

            }
            

            x = 0f;
            y = 90f;
            z = -90f;
            */

            
            targetRotation = Quaternion.Euler(new Vector3(x, y, z));
            StartCoroutine("Rotate");

        }

 

        if (Input.GetKeyDown(KeyCode.D))
        {

            z += 90f;
            targetRotation = Quaternion.Euler(new Vector3(x, y, z));

            StartCoroutine("Rotate");

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            y -= 90f;
            targetRotation = Quaternion.Euler(new Vector3(0, y, 0));

            print("y: " + y);

            StartCoroutine("Rotate");

        }




        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //transform.rotation = Quaternion.Euler(allGameObjectsEdgeArrays[0]);


            targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[0]);
            StartCoroutine("Rotate");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //transform.rotation = Quaternion.Euler(allGameObjectsEdgeArrays[1]);


            targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[1]);
            StartCoroutine("Rotate");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           // transform.rotation = Quaternion.Euler(allGameObjectsEdgeArrays[2]);


            targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[2]);
            StartCoroutine("Rotate");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           // transform.rotation = Quaternion.Euler(allGameObjectsEdgeArrays[3]);

            targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[3]);
            StartCoroutine("Rotate");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
          //  transform.rotation = Quaternion.Euler(allGameObjectsEdgeArrays[4]);


            targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[4]);
            StartCoroutine("Rotate");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
          //  transform.rotation = Quaternion.Euler(allGameObjectsEdgeArrays[5]);


            targetRotation = Quaternion.Euler(allGameObjectsEdgeArrays[5]);
            StartCoroutine("Rotate");
        }


    }

    public void DoubleCheckRotation(GRAVITYPOSITION gravityPosition)
    {
        
    }

    IEnumerator Rotate()
    {
        float durationLimit = 1f;

        isRotating = true;


        playerMovement.IsUncontrolable = true;
        touchDetection.OnDisableControlButton();



        while (transform.rotation != targetRotation && durationLimit >= 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                rotationSpeed * Time.deltaTime);

            durationLimit -= Time.deltaTime;


            yield return null;
        }

        ResetTransform();

        transform.rotation = targetRotation;
        isRotating = false;


        playerMovement.IsUncontrolable = false;
        touchDetection.OnEnableControlButton();


        player.OnEndGravityTransfer();

        /*
        float durationLimit = 1f;

        while (transform.rotation != Quaternion.Euler(angleX, angleY, angleZ) && durationLimit >= 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(angleX, angleY, angleZ),
                rotationSpeed * Time.deltaTime);

            durationLimit -= Time.deltaTime;


            yield return null;
        }

        angleX = Mathf.RoundToInt(angleX);
        angleZ = Mathf.RoundToInt(angleZ);


        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
        */
        /*
        float durationLimit = 1f;


        while (targetRot != this.transform.rotation && durationLimit >= 0f)
        {
            durationLimit -= Time.deltaTime;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

            yield return null;
        }

        print("This rot: " + this.transform.rotation);

        print("New rot:" + newRotation);

        print("target rot" + targetRot);
        */

        //transform.Rotate(newRotation);

    }

    private void ResetTransform()
    {
        transform.position = Vector3.zero;
    }




}