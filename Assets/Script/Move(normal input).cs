using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveNormal : MonoBehaviour
{
	private Playerinput playerInput;
	private Playerinput.WalkActions walk;
	private Moved movement;
	private Look look;
	void Awake() 
	{
		playerInput = new Playerinput();
		walk = playerInput.walk;
		movement = GetComponent<Moved>();
		look = GetComponent<Look>();
		walk.Jump.performed += ctx => movement.Jump();
			
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		movement.ProcessMove(walk.Move.ReadValue<Vector2>());
	}
	private void LateUpdate() 
	{
		look.ProcessLook(walk.Look.ReadValue<Vector2>());
	}
	private void OnEnable()
	{
		walk.Enable();
	}
	private void OnDisable()
	{
		walk.Disable();
	}
}
