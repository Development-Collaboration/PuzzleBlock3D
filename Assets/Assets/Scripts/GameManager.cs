using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { UR, DR, DL, UL, DOWN, UP }


public class GameManager : MonoBehaviour
{
    
    private static GameManager instance = null;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;

            // do allow this later 
            //this.gameObject.hideFlags = HideFlags.HideInHierarchy;             

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }

            return instance;
        }
    }

    private void OnApplicationQuit()
    {
        
    }



}
