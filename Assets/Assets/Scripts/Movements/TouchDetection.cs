using UnityEngine;


//
using System.Collections.Generic;
using UnityEngine.UI;
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

    [SerializeField]
    private Button[] controlButtonArray;

    private Color[] buttonOriginColors;

    private void Awake()
    {

        basicMovementArray = FindObjectsOfType<BasicMovement>();

        playerMovement = GetComponent<PlayerMovement>();


    }

    private void Start()
    {
        //basicMovementArray = FindObjectsOfType(typeof(BasicMovement)) as BasicMovement[];
        //basicMovementArray = FindObjectsOfType<BasicMovement>();

    }

    private void FixedUpdate()
    {
        if(!playerMovement.IsUnmovable)
        {

#if UNITY_EDITOR
            // For Debug
            MouseDrag();
#endif
            // Control Options
            Swipe();

        }


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



    public void OnButtonUL()
    {
        RecordingPosints();

        playerMovement.OnPLayerMovementDirection(DIRECTION.UL);

    }

    public void OnButtonUR()
    {
        RecordingPosints();

        playerMovement.OnPLayerMovementDirection(DIRECTION.UR);

    }

    public void OnButtonDL()
    {
        RecordingPosints();

        playerMovement.OnPLayerMovementDirection(DIRECTION.DL);

    }

    public void OnButtonDR()
    {
        RecordingPosints();

        playerMovement.OnPLayerMovementDirection(DIRECTION.DR);

    }

    public void OnDisableControlButton()
    {
        for (int i = 0; i < controlButtonArray.Length; ++i)
        {
            //controlButtonArray[i].interactable = false;
            controlButtonArray[i].enabled = false;
            controlButtonArray[i].image.color = Color.clear;

        }
    }

    public void OnEnableControlButton()
    {
        for (int i = 0; i < controlButtonArray.Length; ++i)
        {
            //controlButtonArray[i].interactable = true;
            controlButtonArray[i].enabled = true;
            controlButtonArray[i].image.color = Color.white;

        }
    }

   // public void 



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
            RecordingPosints();

            isTouchStart = false;

            playerMovement.OnPLayerMovementDirection(finalDirection);

        }
    }

    private void RecordingPosints()
    {
        for (int i = 0; i < basicMovementArray.Length; ++i)
        {
            if (basicMovementArray[i] != null)
                basicMovementArray[i].RecordPoints();
        }

        playerMovement.RecordGravityPos();

        
    }




}
