using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{	
	[SerializeField] GameObject Enemy;
	
	// Countdown timer fields
	public TMP_Text timerText; // Assign this in the inspector
	public TMP_Text loseText;
	public TMP_Text winnerText; // Reference to TMP Text to show "Winner" message
	public TMP_Text terroristText;
	public TMP_Text counterTerroristText;
	public float timeRemaining = 300; // Countdown timer duration
	public float timeReset = 300;
	private bool isRunning = true;
	public AudioSource audioSource; // Reference to the AudioSource component
	public AudioClip loseSound; // Reference to the sound effect
	public AudioClip winSound;

	// Game objects management
	public GameObject[] gameObjectsToManage; // Array of game objects to manage
	private Vector3[] initialPositions; // Array to store initial positions

	// Throwing tutorial fields
	public ThrowingTutorial throwingTutorial;
	public PlayerHealth playerHealth;
	public int initialThrowCount = 90;
	public float winnerTextDisplayTime = 5f; // Duration to show "Winner" message
	public int healthCount = 100;

	private bool gameEnded = false;
	private int terroristsScore = 0; // Terrorists' score
	private int counterTerroristsScore = 0; // Counter-Terrorists' score

	private void Start()
	{
		
		// Store initial positions of game objects
		initialPositions = new Vector3[gameObjectsToManage.Length];
		for (int i = 0; i < gameObjectsToManage.Length; i++)
		{
			initialPositions[i] = gameObjectsToManage[i].transform.position;
		}
	}

	private void Update()
	{
		if (isRunning && !gameEnded)
		{
			if (timeRemaining > 0)
			{
				timeRemaining = Mathf.Max(timeRemaining - Time.deltaTime, 0); // Ensure time doesn't go below 0
				UpdateTimerText();
			}
			else
			{
				timeRemaining = 0;
				isRunning = false;
				EndGame(false); // Call EndGame with 'false' for a loss
			}
		}
	}

	void UpdateTimerText()
	{
		int minutes = Mathf.FloorToInt(timeRemaining / 60);
		int seconds = Mathf.FloorToInt(timeRemaining % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	// Unified method to end the game (win or lose)
	public void EndGame(bool isWin)
	{
		if (gameEnded) return;

		if (isWin)
		{
			ShowWinnerText();
			Destroy(Enemy);
			Time.timeScale = 0;
		}
		else
		{
			ShowLoserText();
			Time.timeScale = 0;
		}

		// Call Reset after a delay
		StartCoroutine(ResetAfterDelay());
	}

	// Method when timer ends, shows loseText and resets after 5 seconds
	public void ShowLoserText()
	{
		loseText.text = "Terrorists Win!";
		if (audioSource != null && loseSound != null && !audioSource.isPlaying)
		{
			audioSource.PlayOneShot(loseSound);
		}
		timerText.gameObject.SetActive(false);

		// Mark game as ended
		gameEnded = true;

		terroristsScore++;
		terroristText.text = terroristsScore + "  Terrorist";
	}

	// Method to show WinnerText when an object is destroyed and reset after 5 seconds
	public void ShowWinnerText()
	{
		winnerText.gameObject.SetActive(true);
		winnerText.text = "Counter Terrorists Win!";
		if (audioSource != null && winSound != null && !audioSource.isPlaying)
		{
			audioSource.PlayOneShot(winSound);
		}

		// Mark game as ended
		gameEnded = true;

		counterTerroristsScore++;
		counterTerroristText.text = "Counter-Terrorist  " + counterTerroristsScore;
	}

	// Common method to reset the game after a delay
	private IEnumerator ResetAfterDelay()
	{	
		Debug.Log("Reseting");
		yield return new WaitForSecondsRealtime(5f); // Delay of 5 seconds

		ResetGame();
	}

	// Reset all after delay
	public void ResetGame()
	{
		ResetTimer();

		// Reset the state of managed game objects
		for (int i = 0; i < gameObjectsToManage.Length; i++)
		{
			gameObjectsToManage[i].SetActive(false); // Deactivate objects
			gameObjectsToManage[i].transform.position = initialPositions[i];
			gameObjectsToManage[i].SetActive(true); // Reactivate objects
		}

		// Reset throw count
		throwingTutorial.ResetThrowCount(initialThrowCount);
		playerHealth.UpdateCurrentHealth(healthCount);

		// Hide texts after resetting
		winnerText.gameObject.SetActive(false);
		loseText.text = "";

		// Mark game as not ended
		gameEnded = false;
	}

	public void ResetTimer()
	{
		timeRemaining = timeReset; // Reset to initial time
		isRunning = true; // Restart the timer
		timerText.gameObject.SetActive(true);
		loseText.text = "";
		UpdateTimerText(); // Update the display
	}
}
