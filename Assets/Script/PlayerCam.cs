using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
	public float sensX;
	public float sensY;

	public Transform cam;
	public Transform orientation;

	private float mouseX;
	private float mouseY;

	private float multiplier = 0.01f;

	private float xRotation;
	private float yRotation;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void Update()
	{
		MyInput();

		// rotate cam and player
		cam.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		orientation.rotation = Quaternion.Euler(0, yRotation, 0);
	}

	private void MyInput()
	{
		mouseX = Input.GetAxisRaw("Mouse X") + Input.GetAxisRaw("RightStickX");
		
		mouseY = Input.GetAxisRaw("Mouse Y") + Input.GetAxisRaw("RightStickY");
		
		//dùng chuột thì thay x rotation thành -=
		yRotation += mouseX * sensX * multiplier;
		xRotation += mouseY * sensY * multiplier;
		
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
	}
}
