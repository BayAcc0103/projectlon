using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveNormal : MonoBehaviour
{
	private Playerinput playerInput;
	private Playerinput.WalkActions walk;
	private Moved movement;
	void Awake() 
	{
		playerInput = new Playerinput();
		walk = playerInput.walk;
		movement = GetComponent<Moved>();
			
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		movement.ProcessMove(walk.Move.ReadValue<Vector2>());
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
