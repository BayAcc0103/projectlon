using UnityEngine;
using TMPro; // Include this for TextMeshPro

public class CountdownTimerTMP : MonoBehaviour
{
    public TMP_Text timerText; // Assign this in the inspector
    private float timeRemaining = 10; // 5 minutes in seconds
    private bool isRunning = true;
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip endSound; // Reference to the sound effect

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                TimerEnded();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        // Actions to take when the timer ends
        timerText.text = "Terrorists Win!";
        if (audioSource != null && endSound != null)
        {
            audioSource.PlayOneShot(endSound);
        }
    }
}