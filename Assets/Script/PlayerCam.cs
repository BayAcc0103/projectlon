using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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

	private InputDevice headset;
	
	
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		InitializeHeadset();
	}

	private void InitializeHeadset()
	{
		// Find the VR headset device
		var headDevices = new List<InputDevice>();
		InputDevices.GetDevicesAtXRNode(XRNode.Head, headDevices);
		if (headDevices.Count > 0)
		{
			headset = headDevices[0];
		}
		else
		{
			Debug.LogWarning("VR headset not found.");
		}
	}

	public void Update()
	{
		if (headset.isValid)
		{
			// Use VR headset's rotation if available
			UpdateHeadsetRotation();
		}
		else
		{
			// Fallback to mouse and joystick input
			MyInput();
			cam.rotation = Quaternion.Euler(xRotation, yRotation, 0);
			orientation.rotation = Quaternion.Euler(0, yRotation, 0);
		}
	}

	private void UpdateHeadsetRotation()
	{
		Quaternion headsetRotation;

		// Check if the VR headset provides rotation data
		if (headset.TryGetFeatureValue(CommonUsages.deviceRotation, out headsetRotation))
		{
			cam.localRotation = headsetRotation;
		}
	}

	private void MyInput()
	{
		// Handle non-VR input for camera rotation
		mouseX = Input.GetAxisRaw("Mouse X") + Input.GetAxisRaw("RightStickX");
		mouseY = Input.GetAxisRaw("Mouse Y") + Input.GetAxisRaw("RightStickY");

		// Adjust xRotation and yRotation with sensitivity and multiplier
		yRotation += mouseX * sensX * multiplier;
		xRotation -= mouseY * sensY * multiplier;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
	}
}
