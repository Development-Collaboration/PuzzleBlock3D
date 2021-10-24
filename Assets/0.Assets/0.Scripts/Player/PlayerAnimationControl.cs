using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAnimationControl : MonoBehaviour
{
    private float time;
    private bool setTime = false;
    private bool timeDone = false;

    public AnimationName animationName = new AnimationName();

    [SerializeField] private Animator animator;


    [SerializeField]
    private EmojiAnimationCtrl emojiAnimationCtrl;

    // Animation 중 Bool 로 컨트롤 되는 것들 직접 꺼줘야함
    public void OffAllAnimations()
    {

        OffIdleAnimations();

        animator.SetBool(animationName.StandPushDeniedUp, false);

    }

    public void PlayAnimation(PLAYERSTATE ps)
    {

        // Idle 은 OffAllAnimation  타이밍이 다르기 때문ㅇ
        if(ps == PLAYERSTATE.IDLE)
        {
            OnIdle();
            return;
        }

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
            case PLAYERSTATE.GOAL_RESTRICTED:
                OnGoalRestricted();
                break;

            case PLAYERSTATE.STAND_UP:
                OnStandUp();
                break;

        }
    }


    private void OnIdle()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            OffAllAnimations();

            switch (RandomNumberGenerate(2))
            {
                case 0:
                    animator.SetBool(animationName.Idle0, true);
                    break;
                case 1:
                    animator.SetBool(animationName.Idle1, true);
                    break;
                case 2:
                    animator.SetBool(animationName.Idle2, true);
                    break;

            }


        }

    }

    private void OnRunning()
    {
        switch(RandomNumberGenerate(1))
        {
            case 0:
                animator.SetTrigger(animationName.Run0);

                break;
            case 1:
                animator.SetTrigger(animationName.Run1);
                break;

        }

    }

    private void OnStandUp()
    {
        animator.SetBool(animationName.StandPushDeniedUp, true);


    }


    private void OnBlock()
    {

        animator.SetTrigger(animationName.StandPushWalk);


    }

    private void OnBlockRestricted()
    {
        animator.SetTrigger(animationName.StandPushDeniedBlock);



    }


    // fix it later
    private void OnWallRestriected()
    {
        animator.SetTrigger(animationName.StandPushDeniedBlock);
    }

    private void OnGoalRestricted()
    {
        animator.SetTrigger(animationName.StandPushDeniedBlock);

    }
    //


    private void OnGravityTransfer()
    {

    }




    private void OffIdleAnimations()
    {
        animator.SetBool(animationName.Idle0, false);
        animator.SetBool(animationName.Idle1, false);
        animator.SetBool(animationName.Idle2, false);
    }

    //

    // 나중에 Util 로 빼자.
    private int RandomNumberGenerate(int maxNum)
    {
        int min = 0;

        // Random,Range (mininclude, max Exclude!!!)
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
