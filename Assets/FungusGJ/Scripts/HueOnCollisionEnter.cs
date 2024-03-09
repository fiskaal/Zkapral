using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HueOnCollisionEnter : MonoBehaviour
{
    public Volume volume;
    public float timeScale = 0f;
    public float vScale = .2f;
    public float chromaScale = .0f;
    private VolumeParameter<float> hueShift = new VolumeParameter<float>();
    private VolumeParameter<float> intesityVignette = new VolumeParameter<float>();
    private VolumeParameter<float> chromaticAberration = new VolumeParameter<float>();
    public ColorAdjustments CA;
    public Vignette vignette;
    public ChromaticAberration chroma;

    void Start()
    {

        volume.profile.TryGet<ColorAdjustments>(out CA);
        if (CA == null)
            Debug.LogError("No ColorAdjustments found on profile");

        volume.profile.TryGet<ChromaticAberration>(out chroma);
        if (chroma == null)
            Debug.LogError("No ColorAdjustments found on profile");

        volume.profile.TryGet<Vignette>(out vignette);
        if (vignette == null)
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



        if (vignette == null)
        {
            return;
        }

        intesityVignette.value = 0 + vScale; 
        vignette.intensity.SetValue(intesityVignette);

        if (chroma == null)
        {
            return;
        }
        
        chromaticAberration.value = 0 + chromaScale;
        chroma.intensity.SetValue(chromaticAberration);
    }

    
}