using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    //public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    [SerializeField] private float shakeIntensity = 4f;
    [SerializeField] private float shakeDuration = 0.1f;

    private void Awake()
    {
        //Instance = this;

        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        // !!!GetCinemachineComponent 
        cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        

    }

    private void Start()
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

    }

    public void ShakeCamera()
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        StartCoroutine(Timer(shakeDuration));
    }


    public void ShakeCamera(float intensity, float duration)
    {

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        print("intensity: " + intensity + "/ duration: " + duration);

        StartCoroutine(Timer(duration));
        
    }

    IEnumerator Timer(float duration)
    {
        print("ShakeCamera start");

        
        while (duration >= 0f)
        {
            print("duration: " + duration);
            duration -= Time.deltaTime;
            yield return null;

        }

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        

        print("ShakeCamera end");


        yield return null;
    }


}
