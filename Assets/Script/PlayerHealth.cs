using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int playerHealth;

	public void TakeDamage(int dmg)
	{
		playerHealth -= dmg;
		if (playerHealth <= 0)
		{
			playerHealth = 0;
			Debug.Log("YOU DIE");
		}
	}
}
