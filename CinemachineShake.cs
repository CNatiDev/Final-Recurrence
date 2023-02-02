using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake instance;
    public CinemachineVirtualCamera cinemachineVCam;
    private float shakeTimer;

    private void Awake()
    {
        instance = this;
    }
    public void ShakeCamera(float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin
            = cinemachineVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
    public void setTimer(float time)
    {
        shakeTimer = time;
    }
    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.fixedDeltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin
            = cinemachineVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
