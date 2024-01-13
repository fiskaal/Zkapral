using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverCanvas; // Reference to the TextMeshPro object

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

            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Cutlery"))
        {
            // Increase the score
            score += 15;

            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Plates"))
        {
            // Increase the score
            score += 15;

            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Decoration"))
        {
            // Increase the score
            score += 5;

            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Food"))
        {
            // Increase the score
            score += 10;

            // Update the score display
            UpdateScoreText();

            // You can do additional actions here, such as playing a sound or particle effect
        }

        if (other.CompareTag("Player"))
        {
            // Show game over canvas
            gameOverCanvas.gameObject.SetActive(true);

            // Set timescale to zero
            Time.timeScale=0;

            
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
}
