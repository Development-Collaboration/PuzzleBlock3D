using System.Collections;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    private Rigidbody rb;
    //private TouchCtr touchCtr;
    //

    [SerializeField] //[Range( , )]
    private float movementSpeed = 11f;

    private Vector3 targetPos;

    private bool isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //touchCtr = GetComponent<TouchCtr>();

        //
        rb.freezeRotation = true;
    }

    public void OnMovePlayer(TouchCtr.Direction direction)
    {
        if((!isMoving))
        {
            isMoving = true;

            print("Switch Start");

            switch (direction)
            {
                case TouchCtr.Direction.UR:
                    {
                        print("onmove UR");
                        targetPos = new Vector3
                            (transform.position.x + 1, transform.position.y, transform.position.z);

                    }
                    break;

                case TouchCtr.Direction.DR:
                    {
                        print("onmove DR");
                        targetPos = new Vector3
                            (transform.position.x, transform.position.y, transform.position.z - 1);

                    }

                    break;

                case TouchCtr.Direction.DL:
                    {
                        print("onmove DL");
                        targetPos = new Vector3
                            (transform.position.x - 1, transform.position.y, transform.position.z);

                    }

                    break;

                case TouchCtr.Direction.UL:
                    {
                        print("onmove UL");

                        targetPos = new Vector3
                            (transform.position.x, transform.position.y, transform.position.z + 1);

                    }
                    break;
            }
            //
            targetPos = new Vector3
                ((int)targetPos.x, (int)targetPos.y, (int)targetPos.z);

            StartCoroutine("Movements");

        }
    }

    IEnumerator Movements()
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            print("Dis: " + Vector3.Distance(transform.position, targetPos));

            rb.MovePosition(Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime));

            yield return null;

        }

        // ??? Edit ???
        transform.position = targetPos;

        /*
        transform.position = new Vector3
            ((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
        */
        //

        print("Pos: " + transform.position);
        print("TarPos: " + targetPos);

        print("end co");
        isMoving = false;

    }

    //
    public void OnCollisionEnter(Collision collision)
    {
        
    }


    // 
    private void OnCollisionExit(Collision collision)
    {
        
    }

}
