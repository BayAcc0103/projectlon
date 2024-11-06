using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerCam : MonoBehaviour
{
	public float sensX = 100f;
	public float sensY = 100f;
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
		
		// Ensure cam and orientation are assigned
		if (cam == null || orientation == null)
		{
			Debug.LogError("Cam or Orientation transform not assigned in the Inspector.");
		}
	}

	private void InitializeHeadset()
	{
		var headDevices = new List<InputDevice>();
		InputDevices.GetDevicesAtXRNode(XRNode.Head, headDevices);
		if (headDevices.Count > 0)
		{
			headset = headDevices[0];
			
			// Lấy hướng Y ban đầu của thiết bị để thiết lập yRotation
			if (headset.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion initialRotation))
			{
				yRotation = initialRotation.eulerAngles.y;
			}
		}
		else
		{
			Debug.LogWarning("VR headset not found.");
		}
	}


	private void Update()
	{
		if (headset.isValid)
		{
			UpdateHeadsetRotation();
		}
		else
		{
			UpdateNonVRInput();
		}
	}

	private void LateUpdate()
	{
		if (headset.isValid)
		{
			UpdateHeadsetRotation();
		}
	}

	
	private void UpdateHeadsetRotation()
	{
		if (headset.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion headsetRotation))
		{
			// Directly set the rotation without smoothing for VR
			cam.localRotation = headsetRotation;
		}
	}

	private void UpdateNonVRInput()
	{
		// Get input from mouse and joystick
		mouseX = Input.GetAxisRaw("Mouse X") + Input.GetAxisRaw("RightStickX");
		mouseY = Input.GetAxisRaw("Mouse Y") + Input.GetAxisRaw("RightStickY");

		// Adjust xRotation and yRotation with sensitivity and multiplier
		yRotation += mouseX * sensX * multiplier;
		xRotation += mouseY * sensY * multiplier; // - Y for typical mouse look
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		// Apply rotation
		cam.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		orientation.rotation = Quaternion.Euler(0, yRotation, 0);
	}
}
