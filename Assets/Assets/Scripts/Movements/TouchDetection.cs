using UnityEngine;


//
using System.Collections.Generic;
//
public class TouchDetection : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;

    private bool isTouchExecute = false;

    [SerializeField]
    private float minSwipeRange = 200f;

    private DIRECTION finalDirection;


    private BasicMovement[] basicMovementArray;

    private bool isTouchStart = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

    }

    private void Start()
    {
        //basicMovementArray = FindObjectsOfType(typeof(BasicMovement)) as BasicMovement[];
        basicMovementArray = FindObjectsOfType<BasicMovement>();

    }

    private void FixedUpdate()
    {

        // For Debug
        MouseDrag();

        // Control Options
        Swipe();

        //
    }

    public void Swipe()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
                //print("pressed| Pos: " + startTouchPosition);

                isTouchStart = true;
            }

            /////

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentTouchPosition = Input.GetTouch(0).position;

                CalculateDirections();


            }

            if ((Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                endTouchPosition = Input.GetTouch(0).position;
                //print("End Swipe| Pos: " + endTouchPosition);

                FinalDirection();
            }

            ////
        }
    }

    public void RecordButtonPressed()
    {
        for (int i = 0; i < basicMovementArray.Length; ++i)
        {
            if (basicMovementArray[i] != null)
                basicMovementArray[i].RecordPoints();
        }
    }


    public void OnButtonUL()
    {
        RecordButtonPressed();

        playerMovement.OnPLayerMovementDirection(DIRECTION.UL);

    }

    public void OnButtonUR()
    {
        RecordButtonPressed();

        playerMovement.OnPLayerMovementDirection(DIRECTION.UR);

    }

    public void OnButtonDL()
    {
        RecordButtonPressed();

        playerMovement.OnPLayerMovementDirection(DIRECTION.DL);

    }

    public void OnButtonDR()
    {
        RecordButtonPressed();

        playerMovement.OnPLayerMovementDirection(DIRECTION.DR);

    }



    public void MouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;


            //print("Mouse pressed| Pos: " + startTouchPosition);

            isTouchStart = true;

        }

        if (Input.GetMouseButton(0))
        {
            currentTouchPosition = Input.mousePosition;

            CalculateDirections();
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            //print("End Mouse| Distance: " + endTouchPosition);

            FinalDirection();

        }

    }

    private void CalculateDirections()
    {
        var distance = Vector2.Distance(startTouchPosition, currentTouchPosition);

        //print("Dis: " + distance);

        if (distance > minSwipeRange)
        {
            isTouchExecute = true;

            float dy = currentTouchPosition.y - startTouchPosition.y;
            float dx = currentTouchPosition.x - startTouchPosition.x;

            float slope = (dy / dx);

            if (slope > 0)
            {
                if (dy > 0)
                {
                    //print("UP RIGT");
                    finalDirection = DIRECTION.UR;

                }
                else if (dy < 0)
                {
                    //print("Down LEFT");
                    finalDirection = DIRECTION.DL;

                }
            }
            else if (slope < 0)
            {
                if (dy > 0)
                {
                    //print("UP LEFT");
                    finalDirection = DIRECTION.UL;

                }
                else if (dy < 0)
                {
                    //print("Down Right");
                    finalDirection = DIRECTION.DR;

                }
            }
        }
        else
        {
            isTouchExecute = false;

            //print("Too short touch range");
        }
    }

    private void FinalDirection()
    {
        if (isTouchExecute && isTouchStart)
        {
            for(int i = 0; i < basicMovementArray.Length; ++i)
            {
                if(basicMovementArray[i] != null)
                    basicMovementArray[i].RecordPoints();
            }

            isTouchStart = false;

            playerMovement.OnPLayerMovementDirection(finalDirection);

        }
    }




}
