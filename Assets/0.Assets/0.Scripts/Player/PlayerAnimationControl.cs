using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAnimationControl : MonoBehaviour
{
    private float time;
    private bool setTime = false;
    private bool timeDone = false;

    //
    //string Stand = "Stand";

    private const string Idle0 = "Idle0";
    private const string Idle2 = "Idle2";
    private const string Idle1 = "Idle1";

    private const string Run0 = "Run0";
    private const string Run1 = "Run1";

    private const string StandPushHold = "StandPushHold";

    private const string StandPushIdle0 = "StandPushIdle0";
    private const string StandPushIdle1 = "StandPushIdle1";

    private const string StandPushWalk = "StandPushWalk";

    private const string StandPushDeniedBlock = "StandPushDeniedBlock";
    private const string StandPushDeniedUp = "StandPushDeniedUp";




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


            switch (RandomNumberGenerate(2))
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

            /*
             * 
            int min = 0, max = 2;
         // Random,Range (mininclude, maxexclude!!!)

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
            */
        }

    }

    public void PlayAnimation(PLAYERSTATE ps)
    {
        OffAllAnimations();

        switch (ps)
        {
            case PLAYERSTATE.RUNNING:
                OnRunning();
                break;
            case PLAYERSTATE.PUSHING_BLOCK:
                OnBlock();
                break;
            case PLAYERSTATE.BLOCK_RESTRICTED:
                OnBlockRestricted();
                break;
            case PLAYERSTATE.WALL_RESTRICTED:
                OnWallRestriected();
                break;
            case PLAYERSTATE.STAND_UP:
                OnStandUp();
                break;

        }
    }

    private void OnRunning()
    {
        //OffAllAnimations();

        //animator.SetBool(Run0, true);
        //animator.SetTrigger(Run0);

        switch(RandomNumberGenerate(1))
        {
            case 0:
                animator.SetTrigger(Run0);

                break;
            case 1:
                animator.SetTrigger(Run1);
                break;

        }

        /*
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {

            switch (RandomNumberGenerate(1))
            {
                case 0:
                    animator.SetTrigger(Run0);

                    break;
                case 1:
                    animator.SetTrigger(Run1);
                    break;

            }

        }
        */

    }

    private void OnBlock()
    {
        //OffAllAnimations();

        animator.SetTrigger(StandPushWalk);

        //StartCoroutine("Timer", )


    }

    private void OnBlockRestricted()
    {
        //OffAllAnimations();
        animator.SetTrigger(StandPushDeniedBlock);
    }


    // fix it later
    private void OnWallRestriected()
    {
        //OffAllAnimations();
        animator.SetTrigger(StandPushDeniedBlock);

    }

    private void OnStandUp()
    {
        //OffAllAnimations();
        animator.SetBool(StandPushDeniedUp, true);
    }


    public void OnGravityTransfer()
    {

    }

    public void OffAllAnimations()
    {
        //animator.gameObject.SetActive(false);
        //animator.gameObject.SetActive(true);

        
        OffIdleAnimations();

        animator.SetBool(StandPushDeniedUp, false);

    }



    private void OffIdleAnimations()
    {
        animator.SetBool(Idle0, false);
        animator.SetBool(Idle1, false);
        animator.SetBool(Idle2, false);
    }

    private int RandomNumberGenerate(int maxNum)
    {
        int min = 0;
        // Random,Range (mininclude, maxexclude!!!)

        int randNum = Random.Range(min, maxNum + 1);

        return randNum;

    }



    IEnumerator Timer(float endTime)
    {
        setTime = true;
        timeDone = false;

        while (setTime)
        {
            yield return new WaitForSeconds(1f);

            ++time;

            if(time >= endTime)
            {
                setTime = false;
                timeDone = true;
            }

        }
    }
}
