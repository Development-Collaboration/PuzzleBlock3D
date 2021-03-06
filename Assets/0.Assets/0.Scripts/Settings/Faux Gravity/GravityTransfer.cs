using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityTransferPosition
{
    TF, TL, TR, TB,
    BF, BB, BR, BL,
    FR, FL, L, R
}

public class GravityTransfer : MonoBehaviour
{
    [SerializeField] private GameObject centerObject;



    public GravityTransferPosition gravityTransferPosition;

    private string stringBlock = "Block";
    private string stingWall = "Wall";
    private string stingPlayer = "Player";
    private string stringGoal = "Goal";



    Vector3 posGT = Vector3.zero;

    private BlockMovement block;

    public bool IsGoodToGo { get; set; }

    private void Awake()
    {
        IsGoodToGo = false;
    }



    public void RayCheck(Vector3 rayStartPos, string tag)
    {

        RaycastHit hit;

        float rayMaxDistance = 1.25f;


        //Debug.DrawRay(rayStartPos, Vector3.down * rayMaxDistance, Color.green, 3f);


        if (stingPlayer == tag)
        {

            if (Physics.Raycast(rayStartPos, Vector3.down, out hit, rayMaxDistance))
            {
                //print("Raycheck GT: " + hit.transform.tag);

                if (hit.transform.CompareTag(stringBlock))
                {
                    block = hit.collider.GetComponent<BlockMovement>();
                    //block.IsMoveByGT = true;
                    block.OnBlockMovementDirection(DIRECTION.DOWN);

                    if(!block.IsRestricted)
                    {
                        IsGoodToGo = true;

                        //print("1 Block P go");
                        //print("Is Good To Go: " + IsGoodToGo);
                        
                    }

                }

                else if(hit.transform.CompareTag(stingWall) || hit.transform.CompareTag(stringGoal))
                {
                    print("wall or goal");

                    IsGoodToGo = false;


                    return;
                }
                // nothing
                else
                {
                    //print("GT NO tag");

                    IsGoodToGo = true;
                }
            }

            // nothing
            else
            {
                //print("GT NOthing");

                IsGoodToGo = true;
            }



        }

        /////////
        else if (stringBlock == tag)
        {

            if (Physics.Raycast(rayStartPos, Vector3.down, out hit, rayMaxDistance))
            {
                
                if (hit.transform.CompareTag(stringBlock) || hit.transform.CompareTag(stingWall))
                {
                    //return;

                    print("hit.transform.CompareTag: " + hit.transform.tag);

                    IsGoodToGo = false;
                }
                // nothing
                else
                {

                    IsGoodToGo = true;

                }

            }
            // nothing
            else
            {
                //print("GT NOthing");

                IsGoodToGo = true;
            }



        }


    }


    // notusing it
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
    */


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
