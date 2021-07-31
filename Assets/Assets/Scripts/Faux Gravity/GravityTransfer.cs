using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTransfer : MonoBehaviour
{
    [SerializeField] private GameObject centerObject;

    Vector3 posGT = Vector3.zero;

    private BlockMovement block;

    public bool IsGoodToGo { get; set; }

    private void Awake()
    {
        IsGoodToGo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        print("hit GravityTransfer");

        Vector3 otherPos = other.transform.position;

        //other.transform.position = new Vector3(pos.x, -2f, 6f);

        checkPositionCompareWithCenterObject();


        if (other.CompareTag("Player"))
        {
            Debug.Log("from GT, P hit this");

            other.transform.position = new Vector3
                (otherPos.x, this.transform.position.y - 1, transform.position.z);
                

        }
        */
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            checkPositionCompareWithCenterObject();

        }
    }

    public void RayCheck(Vector3 objPos ,Vector3 rayStartPos, string tag)
    {
       // print("ray check on GT sended from P");

        //print("objPos: " + objPos);

       // print("rayStartPos: " + rayStartPos);

        RaycastHit hit;

        float rayMaxDistance = 10f;

        //print("Distance bw this and GT" + );


        Debug.DrawRay(rayStartPos, Vector3.down * rayMaxDistance, Color.green, 3f);

        // Use this one
        /*
        if (Physics.Raycast(rayStartPos, Vector3.down, out hit, rayMaxDistance))
        {
            //Debug.Log("From GT, Hit info: " + hit.transform.tag);
            //Debug.Log("From GT Hit pos: " + hit.transform.position);

            if(hit.transform.CompareTag("Block"))
            {
                block = hit.collider.GetComponent<BlockMovement>();

                block.IsMoveByGT = true;

                block.OnBlockMovementDirection(DIRECTION.DOWN);

                
            } s
        }
        */

        if ("Player" == tag)
        {
            // Check down
            // if nothing player go, 
            //  if 1 block push, hold, (check from block) then move player
            // if 2 two or wall no move;

            if (Physics.Raycast(rayStartPos, Vector3.down, out hit, 1.25f))
            {
                //Debug.Log("From GT, Hit info: " + hit.transform.tag);
                //Debug.Log("From GT Hit pos: " + hit.transform.position);

                if (hit.transform.CompareTag("Block"))
                {
                    block = hit.collider.GetComponent<BlockMovement>();

                    block.IsMoveByGT = true;

                    block.OnBlockMovementDirection(DIRECTION.DOWN);

                    if(!block.IsRestricted)
                    {
                        IsGoodToGo = true;

                        print("1 Block P go");
                        print("Is Good To Go: " + IsGoodToGo);
                        
                    }

                }

                else if(hit.transform.CompareTag("Wall"))
                {
                    return;
                }
            }
            // nothing
            else
            {
                
                IsGoodToGo = true;

                print("Is Good To Go: " + IsGoodToGo);
            }


        }
        else if ("Block" == tag)
        {

            if (Physics.Raycast(rayStartPos, Vector3.down, out hit, 1.25f))
            {
                if (hit.transform.CompareTag("Block") || hit.transform.CompareTag("Wall"))
                {
                    return;
                }
            }
            // nothing
            else
            {

                IsGoodToGo = true;

                print("Is Good To Go: " + IsGoodToGo);
            }


        }


    }


    public void checkPositionCompareWithCenterObject()
    {
        //Vector3 difference = new Vector3(centerObject.transform.position - this.transform.position);

        posGT = this.transform.position;
        posGT = new Vector3(Mathf.RoundToInt(posGT.x), Mathf.RoundToInt(posGT.y), Mathf.RoundToInt(posGT.z));


        print("pos in GT: " + posGT);

        posGT.Normalize();

        print("pos in GT nor: " + posGT);

        float zero = 0f;


        if (posGT.y > zero)
        {
            print("Top");

            if (posGT.z > zero)
            {
                print("TF");
            }
            else if (posGT.z < zero)
            {
                print("TB");
            }

            if (posGT.x > zero)
            {
                print("TR");
            }
            else if (posGT.x < zero)
            {
                print("TL");
            }


        }
        else // 8
        {
            print("Bot");

            if (posGT.x < zero && posGT.z > zero)
            {
                print("FL");
            }

            else if (posGT.x > zero && posGT.z > zero)
            {
                print("FR");
            }

            else if (posGT.x > zero && posGT.z < zero)
            {
                print("BR");
            }

            else if (posGT.x < zero && posGT.z < zero)
            {
                print("BL");
            }

            else
            {
                if (posGT.z > zero)
                {
                    print("BF");
                }
                else if (posGT.z < zero)
                {
                    print("BB");
                }

                if (posGT.x > zero)
                {
                    print("BR");
                }
                else if (posGT.x < zero)
                {
                    print("BL");
                }

            }




        }



    }



    #region // Just Save for later"checkPositionCompareWithCenterObject"

    /*
    public void checkPositionCompareWithCenterObject()
    {
        //Vector3 difference = new Vector3(centerObject.transform.position - this.transform.position);

        posGT = this.transform.position;
        posGT = new Vector3(Mathf.RoundToInt(posGT.x), Mathf.RoundToInt(posGT.y), Mathf.RoundToInt(posGT.z));


        print("pos in GT: " + posGT);

        posGT.Normalize();

        print("pos in GT nor: " + posGT);

        float zero = 0f;


        if(posGT.y > zero)
        {
            print("Top");

            if(posGT.z > zero)
            {
                print("TF");
            }
            else if (posGT.z < zero)
            {
                print("TB");
            }

            if (posGT.x > zero)
            {
                print("TR");
            }
            else if (posGT.x < zero)
            {
                print("TL");
            }


        }
        else // 8
        {
            print("Bot");

            if(posGT.x < zero && posGT.z > zero)
            {
                print("FL");
            }

            else if(posGT.x > zero && posGT.z > zero)
            {
                print("FR");
            }

            else if (posGT.x > zero && posGT.z < zero)
            {
                print("BR");
            }

            else if (posGT.x < zero && posGT.z < zero)
            {
                print("BL");
            }

            else
            {
                if (posGT.z > zero)
                {
                    print("BF");
                }
                else if (posGT.z < zero)
                {
                    print("BB");
                }

                if (posGT.x > zero)
                {
                    print("BR");
                }
                else if (posGT.x < zero)
                {
                    print("BL");
                }

            }




        }



    }
    */
    #endregion (checkPositionCompareWithCenterObject)
}
