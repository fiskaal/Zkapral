using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject playerController;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverCanvas;
    public AudioClip[] glassSounds;
    public AudioClip[] cutlerySounds;
    public AudioClip[] platesSounds;
    public AudioClip hitSound;
    public AudioClip fishSound; // The sound to be played on collision
    public AudioSource audioSource;   // Reference to the AudioSource component


    private void Start()
    {
        // Ensure that the TextMeshPro component is assigned in the Inspector
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro component not assigned to ScoreManager!");
        }

        // Update the initial score display
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the tag "FLOOR"
        if (other.CompareTag("Glass"))
        {
            // Increase the score
            score+=15;
            PlayRandomGlassSound();
            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Cutlery"))
        {
            // Increase the score
            score += 15;
            PlayRandomCutlerySound();
            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Plates"))
        {
            // Increase the score
            score += 15;
            PlayRandomPlatesSound();

            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Decoration"))
        {
            // Increase the score
            score += 5;
            audioSource.PlayOneShot(hitSound);
            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Food"))
        {
            // Increase the score
            score += 10;
            audioSource.PlayOneShot(hitSound);
            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Player"))
        {
            // Show game over canvas
            gameOverCanvas.gameObject.SetActive(true);
            audioSource.PlayOneShot(fishSound);
            // Set timescale to zero
            Time.timeScale=0;
            //playerController.SetActive(false);
            
        }
    }

    // Update the TextMeshPro text with the current score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score;
        }
    }

    void PlayRandomPlatesSound()
    {
        // Check if there are audio clips assigned
        if (platesSounds.Length > 0)
        {
            // Select a random sound from the array
            AudioClip randomSound = platesSounds[Random.Range(0, platesSounds.Length)];

            // Play the selected sound
            audioSource.PlayOneShot(randomSound);
        }
    }

    void PlayRandomGlassSound()
    {
        // Check if there are audio clips assigned
        if (glassSounds.Length > 0)
        {
            // Select a random sound from the array
            AudioClip randomSound = glassSounds[Random.Range(0, glassSounds.Length)];

            // Play the selected sound
            audioSource.PlayOneShot(randomSound);
        }
    }

    void PlayRandomCutlerySound()
    {
        // Check if there are audio clips assigned
        if (cutlerySounds.Length > 0)
        {
            // Select a random sound from the array
            AudioClip randomSound = cutlerySounds[Random.Range(0, cutlerySounds.Length)];

            // Play the selected sound
            audioSource.PlayOneShot(randomSound);
        }
    }
}
