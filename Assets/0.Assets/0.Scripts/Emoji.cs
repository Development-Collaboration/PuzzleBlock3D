using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(EmojiAnimationCtrl))]
[RequireComponent(typeof(Image))]


public class Emoji : MonoBehaviour
{ 

    [SerializeField]
    private Transform tr_Head;

    //[SerializeField]
    private Vector3 offset = new Vector3(0, 4f, 0);

    //[SerializeField]
    private Image emojiImage;

    //[SerializeField]
    private EmojiAnimationCtrl emojiAnimationCtrl;




    private void Awake()
    {
        emojiAnimationCtrl = FindObjectOfType<EmojiAnimationCtrl>();

        emojiImage = GetComponent<Image>();
    }



    // Update is called once per frame
    void LateUpdate()
    {
        // for animator must be !!!! LateUpdate()
        PositionSetting();
      
    }

    private void PositionSetting()
    {
        emojiImage.transform.position = Camera.main.WorldToScreenPoint(tr_Head.position + offset);

        emojiAnimationCtrl.AnimationPosition(Camera.main.WorldToScreenPoint(tr_Head.position + offset));

    }




}
