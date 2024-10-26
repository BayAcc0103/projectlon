using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int playerHealth = 100;
	public TextMeshProUGUI g_healthOfPlayer;

	private GameManager gameManager;

	private void Start()
	{
		// Find the GameManager in the scene
		gameManager = FindObjectOfType<GameManager>();
		UpdateHealStatus();


	}

	public void TakeDamage(int dmg)
	{
		playerHealth = Mathf.Max(playerHealth - dmg, 0); // Ensure health doesn't drop below 0
		UpdateHealStatus();

		HealthZero();
	}
	public void HealthZero()
	{
		if (playerHealth <= 0)
		{
			//gameManager.EndGame(false);
			gameManager.isWin = false;
			gameManager.EndGame();
		}
	}
	
	private void UpdateHealStatus()
	{
		g_healthOfPlayer.text = $"{playerHealth}"; // Use string interpolation for cleaner code
	}

	public void UpdateCurrentHealth(int currentHealth)
	{
		playerHealth = currentHealth;
		UpdateHealStatus();
	}
}
