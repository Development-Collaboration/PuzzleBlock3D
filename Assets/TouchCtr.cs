
using UnityEngine;

public class TouchCtr : MonoBehaviour
{
    private Vector2 startTouchPosition;
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
            print("pressed");
        }
    }

}
