using UnityEngine;

public enum PLAY { PLAY,PAUSE,RESUME,STOP}

public enum BEHAVIOR
{
    ROTATE_By,
    MOVE_By,
    SCALE_To
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

public class ITweenUitility : MonoBehaviour
{
	[SerializeField] private BEHAVIOR behavior;
	[SerializeField] private TRANSFORM transformPoition;
	[SerializeField] private float speed;
	[SerializeField] private EaseType easeType;
	[SerializeField] private LoopType loopType;
	[SerializeField] private float delay;


	public void OnStopiTween()
    {
        iTween.Stop(this.gameObject);
    }

    public void OnStartiTween()
    {

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
			case BEHAVIOR.SCALE_To:
				{
					iTween.ScaleTo(gameObject, iTween.Hash
						(tRANSFORM.ToString(), sPEED, "easeType", eASETYPE.ToString(),
						"loopType", lOOPTYPE.ToString(), "delay", dELAY));
				}
				break;
		}
	}

    private void Start()
    {
        switch(behavior)
        {
            case BEHAVIOR.ROTATE_By:
                {
                    iTween.RotateBy(gameObject,iTween.Hash
                        (transformPoition.ToString(), speed, "easeType", easeType.ToString(),
                        "loopType", loopType.ToString(), "delay", delay));
                }
                break;
			case BEHAVIOR.MOVE_By:
				{
					iTween.MoveBy(gameObject, iTween.Hash
						(transformPoition.ToString(), speed, "easeType", easeType.ToString(),
						"loopType", loopType.ToString(), "delay", delay));
				}
				break;
			case BEHAVIOR.SCALE_To:
				{
					iTween.ScaleTo(gameObject, iTween.Hash
						(transformPoition.ToString(), speed, "easeType", easeType.ToString(),
						"loopType", loopType.ToString(), "delay", delay));
				}
				break;
		}
		
    }


}
