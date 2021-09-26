using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAnimationControl : MonoBehaviour
{
    /*
    private enum PLAYERANIMATION
    {
        Stand,
        Idle0, Idle1, Idle2,
        Run0, Run1,
        StandPushIdle0
    }

    private PLAYERANIMATION playerAnimation;
    */

    //
    string Stand = "Stand";

    string Idle0 = "Idle0";
    string Idle1 = "Idle1";
    string Idle2 = "Idle2";

    string Run0 = "Run0";
    string Run1 = "Run1";

    string StandPushHold = "StandPushHold";

    string StandPushIdle0 = "StandPushIdle0";
    string StandPushIdle1 = "StandPushIdle1";

    string StandPushWalk = "StandPushWalk";
    string StandPushDenied = "StandPushDenied";



    //

    [SerializeField] private Animator animator;


    private void Awake()
    {
        //playerAnimation = PLAYERANIMATION.Stand;
        //animator.SetBool(PLAYERANIMATION.Stand, true);



    }

    public void OnIdle()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            OffAllAnimations();

            // Random,Range (mininclude, maxexclude!!!)

            int min = 0, max = 2;

            int randNum = Random.Range(min, max +1); 

            switch (randNum)
            {
                case 0:
                    animator.SetBool(Idle0, true);
                    break;
                case 1:
                    animator.SetBool(Idle1, true);
                    break;
                case 2:
                    animator.SetBool(Idle2, true);
                    break;

            }
        }
       
    }

    public void OnRunning()
    {
        OffAllAnimations();

        animator.SetBool(Run0, true);
        //animator.SetBool(Idle0, false);
    }

    public void OnWallBlocked()
    {

    }


    public void OffAllAnimations()
    {
        //animator.gameObject.SetActive(false);
        //animator.gameObject.SetActive(true);

        
        OffIdleAnimations();
        animator.SetBool(Run0, false);
        
       
    }



    public void OffIdleAnimations()
    {
        animator.SetBool(Idle0, false);
        animator.SetBool(Idle1, false);
        animator.SetBool(Idle2, false);

    }

     
}
