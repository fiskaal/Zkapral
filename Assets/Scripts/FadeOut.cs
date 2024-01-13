using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public AudioSource music; // Reference to your music AudioSource
    public float fadeSpeed = 0.5f; // Adjust the fade speed as needed

    

    private bool isFading = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeOutMusic());
        }
    }

    

    IEnumerator FadeOutMusic()
    {
        Debug.Log("Fading out music");
        while (music.volume > 0)
        {
            float delta = fadeSpeed * (Time.timeScale == 0 ? Time.unscaledDeltaTime : Time.deltaTime);
            music.volume -= delta;
            Debug.Log("Current volume: " + music.volume);
            yield return null;
        }

        music.Stop(); // Stop the music after fading out
        Debug.Log("Music stopped");
    }
}
