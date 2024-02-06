using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeController : MonoBehaviour
{
    public AudioClip musicClip; // Assign your music clip in the Unity editor
    private AudioSource audioSource;
    private float fadeDuration = 3f; // Adjust the fade duration as needed
    private float fadeOutStartTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.volume = 0f; // Start with zero volume
        audioSource.Play();

        fadeOutStartTime = audioSource.clip.length - 20f; // Start fading out 20 seconds before the end
    }

    void Update()
    {
        // Fade in
        if (Time.time < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, Time.time / fadeDuration);
        }

        // Fade out
        if (Time.time > fadeOutStartTime)
        {
            float timeRemaining = audioSource.clip.length - Time.time;
            audioSource.volume = Mathf.Lerp(0f, 1f, timeRemaining / fadeDuration);
        }
    }
}
