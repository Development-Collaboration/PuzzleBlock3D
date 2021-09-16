using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LineRenderFX : MonoBehaviour
{
    private Vector3 touchPos;
    private Vector3 touchDir;
    
    private Vector3 startPos;
    private Vector3 endPos;

    [Tooltip ("Cam has to be Orthographic")]
    [SerializeField] private Camera camera;

    private Vector3 camPos;
    private Quaternion camRot;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
            

    }

 
    private void Update()
    {

#if UNITY_EDITOR
        LineRenderWithMouse();
#endif
        LineRenderWithTouch();

    }

    private void LineRenderWithTouch()
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;


            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                lineRenderer.enabled = true;

                startPos = Input.GetTouch(0).position;
                startPos.z = 0;

                //print("startPos: " + startPos);

            }

            /////

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                lineRenderer.SetPosition(0, startPos);

                endPos = touchPos;
                endPos.z = 0;

                lineRenderer.SetPosition(1, endPos);

                //print("endPos: " + endPos);


            }

            if ((Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                lineRenderer.enabled = false;

            }

            ////
        }
    }


    private void LineRenderWithMouse()
    {
        camPos = camera.transform.position;
        camRot = camera.transform.rotation;

        touchPos = camera.ScreenToWorldPoint(Input.mousePosition);

       



        if (Input.GetMouseButtonDown(0))
        {
  
            lineRenderer.enabled = true;

            startPos = camera.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 0;


        }

        if (Input.GetMouseButton(0))
        {
            lineRenderer.SetPosition(0, startPos);

            print("startPos: " + startPos);


            endPos = touchPos;
            endPos.z = 0;

            lineRenderer.SetPosition(1, endPos);

            print("endPos: " + endPos);

        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }


        //
        /*
        touchPos = camera.ScreenToWorldPoint(Input.mousePosition);

        touchPos = new Vector3(touchPos.x - camPos.x,
                                touchPos.y - camPos.y);


        if(Input.GetMouseButtonDown(0))
        {
            print("touchpos: " + touchPos);

            lineRenderer.enabled = true;

            startPos = camera.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 0;

            touchDir = touchPos - startPos;
            touchDir.z = 0;
            touchDir = touchDir.normalized;
        }

        if(Input.GetMouseButton(0))
        {
            lineRenderer.SetPosition(0, startPos);

            endPos = touchPos;
            endPos.z = 0;

            lineRenderer.SetPosition(1, endPos);
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }
        */
    }


}
