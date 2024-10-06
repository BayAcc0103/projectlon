using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moved : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	public float speed = 5.0f;
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void ProcessMove(Vector2 input)
	{
		Vector3 MoveDirection = new Vector3(input.x, 0, input.y); ;
		
		controller.Move(transform.TransformDirection(MoveDirection)*speed*Time.deltaTime);
	}
}
