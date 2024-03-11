using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamShake : MonoBehaviour
{

    public static VCamShake instance;

    public CinemachineVirtualCamera vcam;
    public CinemachineBasicMultiChannelPerlin noise;
    public CinemachineHardLockToTarget target;
    public NoiseSettings ns;
    
   

    public void Awake()
    {
        instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        target = vcam.GetCinemachineComponent<CinemachineHardLockToTarget>();
        noise.m_AmplitudeGain = 0.4f;
        noise.m_FrequencyGain = 0.2f;
        target.m_Damping = 3f;
    }

    

    /*
    public static void Shake(float duration)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration));
    }

    public IEnumerator cShake(float duration)
    {
        while (duration > 0)
        {
            noise.m_AmplitudeGain = 1f;
            duration -= _fakeDelta;
            yield return null;
        }

        noise.m_AmplitudeGain = 0f;
    }
    */
}
