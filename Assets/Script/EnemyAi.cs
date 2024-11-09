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
	bool takeDmg = false;
	PlayerHealth playerHealth;

	// States
	public float sightRange, attackRange, meleeAttackRange;
	public bool playerInSightRange,playerInSightRange2, playerInAttackRange, playerInMeleeAttackRange;

	public Vector3 sightRangeBox = new Vector3(6, 6, 6);
	public Vector3 mutil1 = new Vector3(-1, -1,-1);
	
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

	public void FixedUpdate()
	{
		// Check for sight, attack, and melee range
		//playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInSightRange2 = Physics.CheckBox(transform.position, sightRangeBox, Quaternion.identity, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
		playerInMeleeAttackRange = Physics.CheckSphere(transform.position, meleeAttackRange, whatIsPlayer);

		if (!playerInSightRange2 && !playerInAttackRange) Patroling();
		if (playerInMeleeAttackRange && playerInSightRange2) MeleeAttackPlayer(); // Prioritize melee attack
		else if (playerInAttackRange && playerInSightRange2) AttackPlayer();     // Then ranged attack
		else if (playerInSightRange2) ChasePlayer();
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
		takeDmg = true;
		
		if(takeDmg == true)
		{	
			transform.LookAt(player);
			sightRangeBox+=new Vector3(10,10,0);
			attackRange+=5;
		}
		
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
		// Gizmos.color = Color.yellow;
		// Gizmos.DrawWireSphere(transform.position, sightRange);
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position+mutil1,sightRangeBox);
	}
	
	public void ResetEnemyHealth(float resetHealth,Vector3 resetSightRange,float resetattackRange)
	{
		health = resetHealth;
		sightRangeBox = resetSightRange;
		attackRange = resetattackRange;
	}
}
