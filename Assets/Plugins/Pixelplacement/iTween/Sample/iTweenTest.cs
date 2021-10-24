using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenTest : MonoBehaviour
{
	void Start()
	{
		iTween.ScaleTo(gameObject, iTween.Hash
			("y", 5, "easeType", "easeInOutExpo",
			"loopType", "pingPong", "time", 1));
	}
}
