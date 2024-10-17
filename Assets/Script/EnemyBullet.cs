using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public int dmg;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<PlayerHealth>() != null)
		{
			PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

			player.TakeDamage(dmg);

			// destroy projectile
			Destroy(gameObject);
		}
	}
}
