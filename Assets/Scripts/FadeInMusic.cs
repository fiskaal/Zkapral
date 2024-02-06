using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeInTime = 3.0f;
   

    private void Start()
    {
        // Make sure there is an AudioSource component assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is not assigned!");
            return;
        }

        // Start the music at zero volume
        audioSource.volume = 0f;

        // Call the FadeIn method
        StartCoroutine(FadeIn());
       
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // Gradually increase the volume over time
        while (elapsedTime < fadeInTime)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the volume is set to 1 at the end
        audioSource.volume = 1f;
    }

     
}
