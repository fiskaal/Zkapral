using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 3.0f; // You can adjust the fade duration as needed
    private float fadeTimer = 0.0f;
    private bool fading = false;

    void Start()
    {
        
        Invoke("StartFadeOut", 20.0f); // Start fading out after 30 seconds
    }

    void Update()
    {
        if (fading)
        {
            MusicFadeOut();
        }
    }

    void StartFadeOut()
    {
        fading = true;
    }

    void MusicFadeOut()
    {
        fadeTimer += Time.deltaTime;

        float volume = Mathf.Lerp(1.0f, 0.0f, fadeTimer / fadeDuration);
        audioSource.volume = volume;

        if (fadeTimer >= fadeDuration)
        {
            fading = false;
            audioSource.Stop();
        }
    }
}
