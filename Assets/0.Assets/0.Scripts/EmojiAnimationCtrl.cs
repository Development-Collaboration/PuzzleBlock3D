using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private Animator animator;

    //
    //private Emoji emoji;



    private void Awake()
    {
        //emoji = FindObjectOfType<Emoji>();

        //animator.enabled = false;
        //animator.

    }

    public void OnPlayerAnim()
    {


        //animator.SetBool(emojiName.EmoSpiral, true);
        //animator.SetBool(emojiName.EmoQuestionMark, true);
        //animator.SetBool(emojiName.EmojiHeartBroken, true);
        //animator.SetBool(emojiName.EmojiDollar, true);
        //animator.SetBool(emojiName.EmojiDot, true);
        //animator.SetBool(emojiName.EmojiMusicNote, true);
        //animator.SetBool(emojiName.EmojiOkay, true);

        StartCoroutine(PlayAnim());

    }

    IEnumerator PlayAnim()
    {

        animator.enabled = false;

        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(.1f);


        animator.enabled = true;


        yield return new WaitForSeconds(.1f);

        animator.SetBool(emojiName.EmojiOkay, true);


        yield return new WaitForSeconds(.1f);
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
