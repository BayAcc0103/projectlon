using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	[Header(("Game Setting: GUI"))]
	// Countdown timer fields
	public TMP_Text timerText; // Assign this in the inspector
	public TMP_Text loseText;
	public TMP_Text winnerText; // Reference to TMP Text to show "Winner" message
	public TMP_Text terroristText;
	public TMP_Text counterTerroristText;
	public AudioSource audioSource; // Reference to the AudioSource component
	public AudioClip loseSound; // Reference to the sound effect
	public AudioClip winSound;

	[Header(("Game Setting: Game Object"))]
	// Game objects management
	[SerializeField] GameObject[] Enemy; // Array to store multiple enemy GameObjects
	public GameObject[] gameObjectsToManage; // Array of game objects to manage
	private Vector3[] initialPositions; // Array to store initial positions
	//private SpawnEnemy spawnEnemy;
	//[SerializeField] GameObject EnemySpawn;
	[SerializeField] List<GameObject> spawnPoints; // List of spawn points
	private Vector3[] spawnInitialPositions;


	// Throwing tutorial fields
	public ThrowingTutorial throwingTutorial;
	//public PlayerHealth playerHealth;
	[Header(("Game Setting: Stat"))]
	public float timeRemaining = 300; // Countdown timer duration
	public float timeReset = 300;
	//public float timeToReset = 5f;
	private bool isRunning = true;
	public int initialThrowCount = 90;
	public float winnerTextDisplayTime = 5f; // Duration to show "Winner" message
	public int healthCount = 100;
	public float enemyHealthReset = 100f;
	public Vector3 resetSightRange = new(13.9f,17.1f,21.3f);
	public float resetattackRange = 8;
	public bool isWin = false;
	private bool gameEnded = false;
	private int terroristsScore = 0; // Terrorists' score
	private int counterTerroristsScore = 0; // Counter-Terrorists' score
	private PlayerHealth playerHealth;
	private EnemyAI enemyAI;
	
	private void Start()
	{	
		//enemyAI = FindObjectOfType<EnemyAI>();
		playerHealth = FindObjectOfType<PlayerHealth>();
		initialPositions = new Vector3[gameObjectsToManage.Length];
		for (int i = 0; i < gameObjectsToManage.Length; i++)
		{
			initialPositions[i] = gameObjectsToManage[i].transform.position;
		}

		spawnInitialPositions = new Vector3[spawnPoints.Count];
		for (int i = 0; i < spawnPoints.Count; i++)
		{
			spawnInitialPositions[i] = spawnPoints[i].transform.position;
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
				isWin = false;
				EndGame(); // Call EndGame with 'false' for a loss
			}
		}
		
		EndGameSt();
	}

	void UpdateTimerText()
	{
		int minutes = Mathf.FloorToInt(timeRemaining / 60);
		int seconds = Mathf.FloorToInt(timeRemaining % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}


	/// game start -> process -> endgame |--> win --> isWin = true <-- playerHealth > 0
	///									 |--> lose --> isWin = false <-- playerHealth <= 0

	//method to end the game (win or lose)
	public void EndGame()
	{

		if (gameEnded) return;

		Debug.Log("End game");
		if (isWin = true && playerHealth.playerHealth > 0) //&& objectDestroyer.alive == false)
		{
			
			Debug.Log("Is showing winner text");
			ShowWinnerText();
			Debug.Log("You win");
			
			Time.timeScale = 0;

		}
		else
		{	
			isWin = false;
			Debug.Log("Is showing loser text");
			ShowLoserText();
			Debug.Log("You Lose");
		
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
		Debug.Log("Winner text");
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
		Debug.Log("Is Reseting");
		yield return new WaitForSecondsRealtime(5f); // Delay of 5 seconds
		
		Time.timeScale = 1;

		ResetGame();
	}

	// Reset all after delay
	public void ResetGame()
	{

		ResetTimer();
		Debug.Log("Reset the game");
		// Reset the state of managed game objects
		for (int i = 0; i < gameObjectsToManage.Length; i++)
		{
			gameObjectsToManage[i].SetActive(false); // Deactivate objects
			gameObjectsToManage[i].transform.position = initialPositions[i];
			gameObjectsToManage[i].SetActive(true); // Reactivate objects
		}

		for (int i = 0; i < spawnPoints.Count; i++)
		{
			spawnPoints[i].SetActive(false);
			spawnPoints[i].transform.position = spawnInitialPositions[i];
			spawnPoints[i].SetActive(true);
		}

		// Reset throw count
		throwingTutorial.ResetThrowCount(initialThrowCount);
		playerHealth.UpdateCurrentHealth(healthCount);
		ResetEnemies();
		// Hide texts after resetting
		winnerText.gameObject.SetActive(false);
		
		loseText.text = "";
		// Mark game as not ended
		gameEnded = false;
	}

	// GameManager.cs

	private void ResetEnemies()
	{
		for (int i = 0; i < Enemy.Length; i++)
		{
			Enemy[i].SetActive(false); // Deactivate enemy
			EnemyAI enemyAIComponent = Enemy[i].GetComponent<EnemyAI>();
			if (enemyAIComponent != null)
			{
				enemyAIComponent.ResetEnemyHealth(enemyHealthReset,resetSightRange,resetattackRange);
			}
			Enemy[i].transform.position = spawnInitialPositions[i]; // Reset position
			Enemy[i].SetActive(true); // Reactivate enemy
		}
	}

	public void ResetTimer()
	{
		Debug.Log("Reset time");
		timeRemaining = timeReset; // Reset to initial time
		isRunning = true; // Restart the timer
		timerText.gameObject.SetActive(true);
		loseText.text = "";
		UpdateTimerText(); // Update the display
	}
	
	public void EndGameSt()
	{
		if (gameEnded) return; // Exit if game already ended

		if (counterTerroristsScore >= 5)
		{
			// Counter-Terrorists Win
			winnerText.gameObject.SetActive(true);
			winnerText.text = "Counter Terrorists Win!";
			if (audioSource != null && winSound != null && !audioSource.isPlaying)
			{
				audioSource.PlayOneShot(winSound);
			}
			Time.timeScale = 0; // Pause the game
			gameEnded = true; // Mark the game as ended
		}
		else if (terroristsScore >= 5)
		{
			// Terrorists Win
			loseText.text = "Terrorists Win!";
			if (audioSource != null && loseSound != null && !audioSource.isPlaying)
			{
				audioSource.PlayOneShot(loseSound);
			}
			timerText.gameObject.SetActive(false); // Hide timer text
			Time.timeScale = 0; // Pause the game
			gameEnded = true; // Mark the game as ended
		}
	}
}
