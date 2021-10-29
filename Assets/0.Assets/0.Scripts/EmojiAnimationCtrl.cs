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
    private EmojiName emojiName = new EmojiName();

    // Componenets
    private Emoji emoji;
    private Animator animator;
    //private Image emojiImage;

    //
    private string currentEmojiName = "";

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

    

    public void OnPlayerAnim()
    {

        //animator.SetBool(emojiName.EmojiSpiral, true);
        //animator.SetBool(emojiName.EmojiQuestionMark, true);
        //animator.SetBool(emojiName.EmojiHeartBroken, true);
        //animator.SetBool(emojiName.EmojiDollar, true);
        //animator.SetBool(emojiName.EmojiDot, true);
        //animator.SetBool(emojiName.EmojiMusicNote, true);      
        //animator.SetBool(emojiName.EmojiOkay, true);

        //animator.enabled = false;

        StartCoroutine(PlayAnim());

    }




    IEnumerator PlayAnim()
    {


        //yield return new WaitForSeconds(1f);

        animator.enabled = true;

        //yield return new WaitForSeconds(.1f);

        animator.SetBool(emojiName.EmojiSpiral, true);

        yield return new WaitForSeconds(.1f);

        /*

        animator.enabled = false;

        yield return new WaitForSeconds(.1f);


        animator.enabled = true;


        yield return new WaitForSeconds(.1f);

        animator.SetBool(emojiName.EmojiOkay, true);


        yield return new WaitForSeconds(.1f);

        */


        yield return null;

    }

    public void OffAllAnim()
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
