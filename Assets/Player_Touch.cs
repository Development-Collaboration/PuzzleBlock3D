using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Touch : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchControl();

    }

    private void TouchControl()
    {

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            print("Touch pos: " + touch.position);
        }
    }

}
