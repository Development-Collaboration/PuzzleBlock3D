using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;


[RequireComponent(typeof(Animator))]


public class EmojiName
{
    public readonly string EmojiSpiral = "Spiral";
    public readonly string EmojiQuestionMark = "QuestionMark";
    public readonly string EmojiHeartBroken = "HeartBroken";
    public readonly string EmojiDollar = "Dollar";
    public readonly string EmojiDot = "Dot";
    public readonly string EmojiMusicNote = "MusicNote";
    public readonly string EmojiOkay = "Okay";


}

public class EmojiAnimationCtrl : MonoBehaviour
{
    public EmojiName emojiName = new EmojiName();

    // Componenets
    private Emoji emoji;
    private Animator animator;
    //private Image emojiImage;

    private void Awake()
    {
        emoji = FindObjectOfType<Emoji>();

        //emojiImage = emoji.GetComponent<Image>();
        animator = GetComponent<Animator>();

        animator.enabled = true;

    }

    public void AnimationPosition(Vector3 pos)
    {      
        animator.transform.position = pos;
    }

    

    public void PlayEmojiAnimation(string name)
    {

        switch(name)
        {
            case "Spiral":
                animator.SetBool(emojiName.EmojiSpiral, true);
                break;

            case "QuestionMark":
                animator.SetBool(emojiName.EmojiQuestionMark, true);
                break;

            case "HeartBroken":
                animator.SetBool(emojiName.EmojiHeartBroken, true);
                break;

            case "Dollar":
                animator.SetBool(emojiName.EmojiDollar, true);
                break;

            case "Dot":
                animator.SetBool(emojiName.EmojiDot, true);
                break;
            case "MusicNote":
                animator.SetBool(emojiName.EmojiMusicNote, true);
                break;
            case "Okay":
                animator.SetBool(emojiName.EmojiOkay, true);
                break;
        }

        //animator.SetBool(emojiName.EmojiSpiral, true);
        //animator.SetBool(emojiName.EmojiQuestionMark, true);
        //animator.SetBool(emojiName.EmojiHeartBroken, true);
        //animator.SetBool(emojiName.EmojiDollar, true);
        //animator.SetBool(emojiName.EmojiDot, true);
        //animator.SetBool(emojiName.EmojiMusicNote, true);      
        //animator.SetBool(emojiName.EmojiOkay, true);


    }

    public void OffAllEmojiAnimation()
    {


        animator.SetBool(emojiName.EmojiSpiral, false);
        animator.SetBool(emojiName.EmojiQuestionMark, false);
        animator.SetBool(emojiName.EmojiHeartBroken, false);
        animator.SetBool(emojiName.EmojiDollar, false);
        animator.SetBool(emojiName.EmojiDot, false);
        animator.SetBool(emojiName.EmojiMusicNote, false);
        animator.SetBool(emojiName.EmojiOkay, false);


    }

}
