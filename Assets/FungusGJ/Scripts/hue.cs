using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class hue : MonoBehaviour
{
    public GameObject cam;
    public float lastValue;
    private ShadowsMidtonesHighlights shadowMidHigh;
    public VolumeProfile profile;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main.gameObject;
    }


    [SerializeField] private VolumeProfile gameVolume;
    private ColorAdjustments colorAdjustments;
    

    public void Awake()
    {
        ColorAdjustments cA;
        if (gameVolume.TryGet<ColorAdjustments>(out cA))
        {
            colorAdjustments = cA;
            colorAdjustments.hueShift.overrideState = true;
            colorAdjustments.hueShift.value = 0;
        }
    }







    // Update is called once per frame
    /*private void FixedUpdate()
    {
        
            lastValue = GetComponent<Slider>().value;
            if (profile.TryGet<ShadowsMidtonesHighlights>(out shadowMidHigh))
            {
                Vector4 shadowVal = shadowMidHigh.shadows.value;
                shadowMidHigh.shadows.overrideState = true;
                shadowMidHigh.shadows.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(1, 1, 1, lastValue)));
            }
        
    }
    */
}