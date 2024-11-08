using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
	public NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	public float health;

	// Patroling
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	// Attacking
	public float timeBetweenAttacks;
	bool alreadyAttacked;
	public int meleeDamage = 0;
	public GameObject projectile;

	PlayerHealth playerHealth;

	// States
	public float sightRange, attackRange, meleeAttackRange;
	public bool playerInSightRange, playerInAttackRange, playerInMeleeAttackRange;

	private void Awake()
	{
		player = GameObject.Find("Player")?.transform;
		if (player == null)
		{
			Debug.LogError("Player not found. Ensure the 'Player' GameObject exists.");
		}

		agent = GetComponent<NavMeshAgent>();
		if (agent == null)
		{
			Debug.LogError("NavMeshAgent not found on " + gameObject.name);
		}
	}

	private void FixedUpdate()
	{
		// Check for sight, attack, and melee range
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
		playerInMeleeAttackRange = Physics.CheckSphere(transform.position, meleeAttackRange, whatIsPlayer);

		if (!playerInSightRange && !playerInAttackRange) Patroling();
		if (playerInMeleeAttackRange && playerInSightRange) MeleeAttackPlayer(); // Prioritize melee attack
		else if (playerInAttackRange && playerInSightRange) AttackPlayer();     // Then ranged attack
		else if (playerInSightRange) ChasePlayer();
	}

	private void Patroling()
	{
		if (!walkPointSet) SearchWalkPoint();

		if (walkPointSet)
			agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		// Walkpoint reached
		if (distanceToWalkPoint.magnitude < 1f)
			walkPointSet = false;
	}

	private void SearchWalkPoint()
	{
		// Calculate random point in range
		float randomZ = Random.Range(-walkPointRange, walkPointRange);
		float randomX = Random.Range(-walkPointRange, walkPointRange);

		walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z
		+ randomZ);

		if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
			walkPointSet = true;
	}

	private void ChasePlayer()
	{
		agent.SetDestination(player.position);
	}

	private void AttackPlayer()
	{
		// Make sure enemy doesn't move
		agent.SetDestination(transform.position);

		transform.LookAt(player);

		if (!alreadyAttacked)
		{
			// Ranged attack code here
			Rigidbody rb = Instantiate(projectile, transform.position, 
			Quaternion.identity).GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
			rb.AddForce(transform.up * 8f, ForceMode.Impulse);

			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}
	}

	private void MeleeAttackPlayer()
	{
		// Make sure the enemy doesn't move
		agent.SetDestination(transform.position);

		// Look at the player
		transform.LookAt(player);

		if (!alreadyAttacked)
		{
			// Trigger the sword swing animation
			SwordSwing swordSwing = GetComponentInChildren<SwordSwing>();
			if (swordSwing != null)
			{
				swordSwing.StartSwing();
			}

			// Deal damage to the player
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
			if (playerHealth != null)
			{
				int damageAmount = meleeDamage;
				playerHealth.TakeDamage(damageAmount);  // Deal damage to the player
			}

			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);  // Set up the cooldown between attacks
		}
	}
	private void ResetAttack()
	{
		alreadyAttacked = false;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			health = 0; // Clamp health to zero
			Invoke(nameof(DestroyEnemy), 0.5f);
		}
	}

	private void DestroyEnemy()
	{
		gameObject.SetActive(false);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, meleeAttackRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, sightRange);
	}
	
	public void ResetEnemyHealth(float resetHealth)
	{
		health = resetHealth;
	}
}
