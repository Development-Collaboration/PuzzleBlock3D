using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameObjectsTransform : MonoBehaviour
{

    //public enum DIRECTION { UR, DR, DL, UL, DOWN, UP }

    private PlayerMovement playerMovement;

    private Vector3[] allGameObjectsEdgeArrays = new Vector3[6];

    private TouchDetection touchDetection;

    [SerializeField] private float rotationSpeed = 5f;

    private Quaternion targetRotation;

    public bool isRotating { get; set; }

     

    private void Awake()
    {
        allGameObjectsEdgeArrays[0] = new Vector3(0, 0, 0);
        allGameObjectsEdgeArrays[1] = new Vector3(-90, 0, 0);
        allGameObjectsEdgeArrays[2] = new Vector3(-180, 0, 0);
        allGameObjectsEdgeArrays[3] = new Vector3(90, 0, 0);
        allGameObjectsEdgeArrays[4] = new Vector3(0, 0, 90);
        allGameObjectsEdgeArrays[5] = new Vector3(0, 0, -90);


        isRotating = false;

        playerMovement = FindObjectOfType<PlayerMovement>();

        touchDetection = FindObjectOfType<TouchDetection>();
    }

    public void InstanteRotation(GravityPosition gravityPosition)
    {
        print("InstanteRotation");


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

        transform.rotation = targetRotation;

    }

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

    private void Update()
    {
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

    IEnumerator Rotate()
    {
        print("co rotate start");

        float durationLimit = 1f;

        isRotating = true;


        playerMovement.IsUnmovable = true;
        touchDetection.OnDisableControlButton();

        while (transform.rotation != targetRotation && durationLimit >= 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                rotationSpeed * Time.deltaTime);

            durationLimit -= Time.deltaTime;


            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;


        playerMovement.IsUnmovable = false;
        touchDetection.OnEnableControlButton();


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

    


}