using UnityEngine;
using System;
using System.Collections.Generic;



public enum PLAY { PLAY,PAUSE,RESUME,STOP}

public enum BEHAVIOR
{
    ROTATE_By,
    MOVE_By,
    SCALE_To,

	// change later
	GOAL
}

public enum TRANSFORM { X,Y,Z }

public enum EaseType
{
	easeInQuad,
	easeOutQuad,
	easeInOutQuad,
	easeInCubic,
	easeOutCubic,
	easeInOutCubic,
	easeInQuart,
	easeOutQuart,
	easeInOutQuart,
	easeInQuint,
	easeOutQuint,
	easeInOutQuint,
	easeInSine,
	easeOutSine,
	easeInOutSine,
	easeInExpo,
	easeOutExpo,
	easeInOutExpo,
	easeInCirc,
	easeOutCirc,
	easeInOutCirc,
	linear,
	spring,
	/* GFX47 MOD START */
	//bounce,
	easeInBounce,
	easeOutBounce,
	easeInOutBounce,
	/* GFX47 MOD END */
	easeInBack,
	easeOutBack,
	easeInOutBack,
	/* GFX47 MOD START */
	//elastic,
	easeInElastic,
	easeOutElastic,
	easeInOutElastic,
	/* GFX47 MOD END */
	punch
}

public enum LoopType { none, loop, pingPong }

//System.Serializable
[Serializable]
public struct Attributes
{
	public BEHAVIOR behavior;
	public TRANSFORM transformPoition;
	public float speed;
	public EaseType easeType;
	public LoopType loopType;
	public float delay;
}


public class ITweenUitility : MonoBehaviour
{
	public List<Attributes> ITweenAttributes = new List<Attributes>();
    /*
	[SerializeField] private BEHAVIOR behavior;
	[SerializeField] private TRANSFORM transformPoition;
	[SerializeField] private float speed;
	[SerializeField] private EaseType easeType;
	[SerializeField] private LoopType loopType;
	[SerializeField] private float delay;
	*/

    private void Awake()
    {
		//ITweenAttributes = new List<Attributes>();
	}


    public void OnPauseiTween()
    {
        iTween.Pause(gameObject);
    }

    public void OnResumeiTween()
    {
		iTween.Resume(gameObject);
    }

	public void OnRestartiTween()
	{
		iTween.Stop(gameObject);

		StartSetting();
	}

	public void SetITween(BEHAVIOR bEHAVIOR, TRANSFORM tRANSFORM, float sPEED, EaseType eASETYPE, LoopType lOOPTYPE, float dELAY)
    {

		switch (bEHAVIOR)
		{
			case BEHAVIOR.ROTATE_By:
				{
					iTween.RotateBy(gameObject, iTween.Hash
						(tRANSFORM.ToString(), sPEED, "easeType", eASETYPE.ToString(),
						"loopType", lOOPTYPE.ToString(), "delay", dELAY));
				}
				break;
			case BEHAVIOR.MOVE_By:
				{
					iTween.MoveBy(gameObject, iTween.Hash
						(tRANSFORM.ToString(), sPEED, "easeType", eASETYPE.ToString(),
						"loopType", lOOPTYPE.ToString(), "delay", dELAY));
				}
				break;

		}
	}

	private void StartSetting()
    {
		foreach (Attributes attributes in ITweenAttributes)
		{
			switch (attributes.behavior)
			{

				case BEHAVIOR.ROTATE_By:
					{
						iTween.RotateBy(gameObject, iTween.Hash
							(attributes.transformPoition.ToString(), attributes.speed,
							"easeType", attributes.easeType.ToString(),
							"loopType", attributes.loopType.ToString(),
							"delay", attributes.delay));
					}
					break;

				case BEHAVIOR.MOVE_By:
					{
						iTween.MoveBy(gameObject, iTween.Hash
							(attributes.transformPoition.ToString(), attributes.speed,
							"easeType", attributes.easeType.ToString(),
							"loopType", attributes.loopType.ToString(),
							"delay", attributes.delay));
					}
					break;
			}


		}

	}

	private void Start()
    {
		StartSetting();
	}
	

}
