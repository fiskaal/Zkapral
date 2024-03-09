using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HueOnCollisionEnter : MonoBehaviour
{
    public Volume volume;
    public float timeScale = 1f;
    private VolumeParameter<float> hueShift = new VolumeParameter<float>();
    public ColorAdjustments CA;

    void Start()
    {

        volume.profile.TryGet<ColorAdjustments>(out CA);
        if (CA == null)
            Debug.LogError("No ColorAdjustments found on profile");
    }
    void Update()
    {
        if (CA == null)
        {
            return;
        }

        hueShift.value = Mathf.PingPong(Time.time * timeScale, 180f);
        CA.hueShift.SetValue(hueShift);
    }
}