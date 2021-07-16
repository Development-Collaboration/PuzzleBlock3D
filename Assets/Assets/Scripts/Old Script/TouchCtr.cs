
using UnityEngine;


public class TouchCtr : MonoBehaviour
{
    private PlayerCtr playerCtr;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;

    private bool isTouchExecute = false;

    [SerializeField]
    private float minSwipeRange = 200f;

    private DIRECTION finalDirection;

    private void Awake()
    {
        playerCtr = GetComponent<PlayerCtr>();

    }


    private void FixedUpdate()
    {
        Swipe();

        MouseDrag();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
                //print("pressed| Pos: " + startTouchPosition);
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

    public void MouseDrag()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;


            //print("Mouse pressed| Pos: " + startTouchPosition);
        }

        if(Input.GetMouseButton(0))
        {
            currentTouchPosition = Input.mousePosition;

            CalculateDirections();
        }

        if(Input.GetMouseButtonUp(0))
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
        if(isTouchExecute)
        {
            playerCtr.OnPLayerMovementDirection(finalDirection);

        }
    }





    /*
    
    private string positionText;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    [SerializeField] private float swipeRange;
    [SerializeField] private float tapRange;

    private void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            startTouchPosition = Input.GetTouch(0).position;
            //print("pressed");
        }

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentTouchPosition - startTouchPosition;

            if(!stopTouch)
            {
                if(Distance.x < (-swipeRange))
                {
                    positionText = "Left";
                    stopTouch = true;
                }
                else if (Distance.x > (swipeRange))
                {
                    positionText = "Right";
                    stopTouch = true;
                }
                else if (Distance.y > (swipeRange))
                {
                    positionText = "Up";
                    stopTouch = true;
                }
                else if (Distance.x < (-swipeRange))
                {
                    positionText = "Down";
                    stopTouch = true;
                }


            }
        }

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distan = endTouchPosition - startTouchPosition;

            if((Mathf.Abs(Distan.x) < tapRange) && (Mathf.Abs(Distan.y) < tapRange))
            {
                positionText = "Tap";
            }
           
        }


    }
    */

}