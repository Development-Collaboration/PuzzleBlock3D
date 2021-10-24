using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emoji : MonoBehaviour
{

    //[SerializeField]
    private Image emojiImage;

    [SerializeField]
    private Transform tr_Head;

    [SerializeField]
    private EmojiAnimationCtrl emojiAnimationCtrl;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 4f, 0);


    private void Awake()
    {
        //emoji = Instantiate(prefabUi, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        //tr_Head = tran


        emojiImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        emojiImage.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        emojiImage.transform.position = Camera.main.WorldToScreenPoint(tr_Head.position + offset);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //emoji.enabled = true;


            emojiAnimationCtrl.OnPlayerAnim();


        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //emoji.enabled = false;
            emojiAnimationCtrl.OffAllAnim();


        }
        

        //
    }

    public void OffEmoji()
    {
        print("OffEmoji");
        emojiImage.enabled = false;
    }




}
