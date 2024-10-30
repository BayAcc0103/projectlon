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
	[SerializeField] GameObject Enemy;
	public GameObject[] gameObjectsToManage; // Array of game objects to manage
	private Vector3[] initialPositions; // Array to store initial positions
	//private SpawnEnemy spawnEnemy;
	//[SerializeField] GameObject EnemySpawn;
	[SerializeField] List<GameObject> spawnPoints; // List of spawn points


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
	public bool isWin = false;
	private bool gameEnded = false;
	private int terroristsScore = 0; // Terrorists' score
	private int counterTerroristsScore = 0; // Counter-Terrorists' score
	private PlayerHealth playerHealth;
	private EnemyAI enemyAI;
	
	
	
	//private ObjectDestroyer objectDestroyer;


	private void Start()
	{	
		enemyAI = FindObjectOfType<EnemyAI>();
		playerHealth = FindObjectOfType<PlayerHealth>();
		//objectDestroyer = gameObject.GetComponent<ObjectDestroyer>();
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
				isWin = false;
				EndGame(); // Call EndGame with 'false' for a loss
			}
		}
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
			Enemy.SetActive(false);
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

		// Reset throw count
		throwingTutorial.ResetThrowCount(initialThrowCount);
		playerHealth.UpdateCurrentHealth(healthCount);

        foreach (var enemyObj in gameObjectsToManage)
        {
            if (enemyObj.layer == LayerMask.NameToLayer("Enemy") && spawnPoints.Count > 0)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Count);
                enemyObj.transform.position = spawnPoints[spawnIndex].transform.position;
                enemyObj.SetActive(true);
            }
        }

        if (enemyAI != null)
		{	
			Debug.Log("Reset enemy health");
			enemyAI.ResetEnemyHealth(enemyHealthReset); // Reset enemy health
		}
		

		// Hide texts after resetting
		winnerText.gameObject.SetActive(false);
		loseText.text = "";

		// Mark game as not ended
		gameEnded = false;
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
}
