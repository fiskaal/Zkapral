using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public float timeScale = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
