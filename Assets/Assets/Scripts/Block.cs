using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private PlayerCtr playerCtr;

    private Rigidbody rb;

    private string player = "Player";
    private string block = "Block";
    private string wall = "Wall";

    public bool IsBlockCollideWithPlayer { get; set; }

    [SerializeField] //[Range( , )]
    private float movementSpeed = 11f;
    private int movementDistance = 1;

    private Vector3 targetPos;
    private bool isMoving = false;

    private bool[] isRestrictedDirectionArray = new bool[4] { false, false, false, false };

    private bool isTriggerOn = false;

    private bool isCollideWithBlock = false;
    private bool isCollideWithWall = false;


    private void Awake()
    {
        playerCtr = FindObjectOfType<PlayerCtr>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        IsBlockCollideWithPlayer = false;

    }



    public void OnBlockMove(DIRECTION direction)
    {
        if(!isMoving)
        {
            DirectionDecision(direction);

            StartCoroutine("ExecuteMovements");

        }

    }


    IEnumerator ExecuteMovements()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {

            rb.MovePosition(Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime));

            yield return null;

        }

        transform.position = targetPos;
        isMoving = false;


    }


    private void DirectionDecision(DIRECTION direction)
    {

        isMoving = true;

        switch (direction)
        {
            case DIRECTION.UR:
                {
                    //print("onmove UR");
                    targetPos = new Vector3
                        (transform.position.x + movementDistance, transform.position.y, transform.position.z);

                }
                break;

            case DIRECTION.DR:
                {
                    //print("onmove DR");
                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z - movementDistance);

                }

                break;

            case DIRECTION.DL:
                {
                    //print("onmove DL");
                    targetPos = new Vector3
                        (transform.position.x - movementDistance, transform.position.y, transform.position.z);

                }

                break;

            case DIRECTION.UL:
                {
                    //print("onmove UL");

                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z + movementDistance);

                }
                break;
        }
        //
        targetPos = new Vector3
            ((int)targetPos.x, (int)targetPos.y, (int)targetPos.z);


    }



}
