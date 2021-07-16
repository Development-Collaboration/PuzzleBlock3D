using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    protected Rigidbody rb;

    protected string block = "Block";
    protected string wall = "Wall";

    [SerializeField] //[Range( , )]
    protected float movementSpeed = 11f;

    //[SerializeField] //[Range( , )]
    protected int movementDistance = 1;

    protected Vector3 currentPos;
    protected Vector3 targetPos;
    protected bool isMoving = false;

    public bool IsRestricted { get; set; }


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isMoving = false;
        IsRestricted = false;
    }

    protected virtual void MovementsControl(DIRECTION direction)
    {
        if ((!isMoving))
        {
            currentPos = this.transform.position;
            IsRestricted = false;

            // + wall detection
            DirectionDecision(direction);

            // execute at Block.cs
            //MoveBlock(direction);

            if (IsRestricted)
            {
                targetPos = currentPos;
                return;
            }
            // execute player move
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

    protected virtual void DirectionDecision(DIRECTION direction)
    {
        RaycastHit hit;
        Vector3 rayTransformDirection = Vector3.zero;

        switch (direction)
        {
            case DIRECTION.UR:
                {
                    //print("onmove UR");
                    targetPos = new Vector3
                        (transform.position.x + movementDistance, transform.position.y, transform.position.z);

                    rayTransformDirection = transform.TransformDirection(Vector3.right);
                }
                break;

            case DIRECTION.DR:
                {
                    //print("onmove DR");
                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z - movementDistance);

                    rayTransformDirection = transform.TransformDirection(Vector3.back);

                }

                break;

            case DIRECTION.DL:
                {
                    //print("onmove DL");
                    targetPos = new Vector3
                        (transform.position.x - movementDistance, transform.position.y, transform.position.z);

                    rayTransformDirection = transform.TransformDirection(Vector3.left);

                }

                break;

            case DIRECTION.UL:
                {
                    //print("onmove UL");

                    targetPos = new Vector3
                        (transform.position.x, transform.position.y, transform.position.z + movementDistance);

                    rayTransformDirection = transform.TransformDirection(Vector3.forward);

                }
                break;
        }
        //
        targetPos = new Vector3
            ((int)targetPos.x, (int)targetPos.y, (int)targetPos.z);


        // Wall Detection

        Debug.DrawRay(transform.position, transform.TransformDirection(rayTransformDirection) * movementDistance, Color.red, 0.5f);
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(rayTransformDirection),
            out hit, (movementDistance)))
        {
            print("Hit info: " + hit.transform.tag);

            if (hit.transform.CompareTag(wall))
            {
                CollideWithWall(hit);
            }

            if (hit.transform.CompareTag(block))
            {

                CollideWithBlock(hit, direction);
            }
        }
    }

    protected virtual void CollideWithWall(RaycastHit hit)
    {

    }

    protected virtual void CollideWithBlock(RaycastHit hit, DIRECTION direction)
    {

    }


    
}