using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
		iTween.RotateBy(gameObject,
			iTween.Hash("x", .25, "easeType", "easeInOutBack",
			"loopType", "pingPong", "delay", .4));
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            print("Return Pressed: Stop");
            iTween.Pause(this.gameObject);
            //iTween.Stop(this.gameObject);

            //WaitForSeconds;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space Pressed: Restart");

            iTween.Resume(this.gameObject);

            /*
            iTween.RotateBy(gameObject,
              iTween.Hash("x", .25, "easeType", "easeInOutBack",
              "loopType", "pingPong", "delay", .4));
            */
        }
    }
}

