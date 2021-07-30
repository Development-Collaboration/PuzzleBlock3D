using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTransfer : MonoBehaviour
{
    [SerializeField] private GameObject centerObject;

    Vector3 posGT = Vector3.zero;

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

    public void rayCheck(Vector3 objPos ,Vector3 rayStartPos)
    {
        print("ray check on GT sended from P");

        print("objPos: " + objPos);

        print("rayStartPos: " + rayStartPos);

        RaycastHit hit;

        float rayMaxDistance = 10f;

        //print("Distance bw this and GT" + );



        if (objPos.z < transform.position.z)
        {
            print("this is behind GT , shoot ray bot");

            Debug.DrawRay(rayStartPos, Vector3.down * rayMaxDistance, Color.blue, 3f);

        }
        else if (objPos.z > transform.position.z)
        {
            print("this is front of GT , shoot ray bot");

            Debug.DrawRay(rayStartPos, Vector3.down * rayMaxDistance, Color.yellow, 3f);

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
