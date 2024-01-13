using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;  // Set the countdown time in seconds
    public GameObject countdownCanvas;      // Reference to the Canvas that will appear after the countdown
    public TextMeshProUGUI timerText;   // Reference to the TextMeshProUGUI component for displaying the timer

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;

        // Ensure that TextMeshPro is available and the timerText is assigned
        if (timerText == null)
        {
            Debug.LogError("TimerText is not assigned. Please assign a TextMeshProUGUI component.");
        }
    }

    void Update()
    {
        // Update the countdown timer
        currentTime -= Time.deltaTime;

        // Display the updated time in the TextMeshProUGUI component
        if (timerText != null)
        {
            timerText.text = "TIME REMAINING: " + Mathf.CeilToInt(currentTime).ToString();
        }

        // Check if the countdown is finished
        if (currentTime <= 0)
        {
            currentTime = 0;  // Ensure the timer does not go negative

            // Pause the game by setting timeScale to 0
            Time.timeScale = 0;

            // Activate the countdownCanvas
            if (countdownCanvas != null)
            {
                countdownCanvas.gameObject.SetActive(true);
            }
        }
    }

    void OnDisable()
    {
        // Ensure timeScale is set back to 1 if the script is disabled
        Time.timeScale = 1;
    }
}
