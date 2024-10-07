using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Moved : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool isGrounded;
	public float speed = 5.0f;
	public float gravity = 0.0f;
	public float jumpForce = 0.0f;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		isGrounded = controller.isGrounded;	
	}
	
	public void ProcessMove(Vector2 input)
	{
		Vector3 MoveDirection = Vector3.zero;
		MoveDirection.x = input.x;
		MoveDirection.z = input.y;
		
		controller.Move(transform.TransformDirection(MoveDirection)*speed*Time.deltaTime);
		playerVelocity.y += gravity	*Time.deltaTime;
		if(isGrounded&& playerVelocity.y < 0)
		{
			playerVelocity.y = -2;
		}
		controller.Move(playerVelocity*Time.deltaTime);
		
		
	}
	public void Jump()
	{
		if(isGrounded)
		{
			playerVelocity.y = Mathf.Sqrt(jumpForce *-3.0f *gravity);
		}
	}
}
