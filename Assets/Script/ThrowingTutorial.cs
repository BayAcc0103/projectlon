using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingTutorial : MonoBehaviour
{
	[Header("References")]
	public Transform cam;
	public Transform attackPoint;
	public GameObject objectToThrow;
	public AudioSource audioSource; // Reference to the AudioSource component
	public AudioClip throwSound; // Reference to the sound effect
	public TextMeshProUGUI throwCountText;

	[Header("Settings")]
	public int totalThrows;
	public float throwCooldown;

	[Header("Throwing")]
	public KeyCode throwKey = KeyCode.Mouse0;
	public float throwForce;
	public float throwUpwardForce;

	bool readyToThrow;

	private void Start()
	{
		readyToThrow = true;
		UpdateThrowCountDisplay();

	}

	public void Update()
	{
		if ((Input.GetKeyDown(throwKey) ||  Input.GetButtonDown("ButtonX")) && readyToThrow && totalThrows > 0)
		{
			Throw();
		}
	}

	private void Throw()
	{
		readyToThrow = false;

		// instantiate object to throw
		GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

		// get rigidbody component
		Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

		// calculate direction
		Vector3 forceDirection = cam.transform.forward;

		RaycastHit hit;

		if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
		{
			forceDirection = (hit.point - attackPoint.position).normalized;
		}

		// add force
		Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

		projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

		// Play throw sound
		if (audioSource != null && throwSound != null)
		{
			audioSource.PlayOneShot(throwSound);
		}

		totalThrows--;
		UpdateThrowCountDisplay();

		// implement throwCooldown
		Invoke(nameof(ResetThrow), throwCooldown);
	}

	private void UpdateThrowCountDisplay()
	{
		// Cập nhật văn bản TextMeshPro với số lượng ném còn lại
		throwCountText.text = "" + totalThrows;
	}

	private void ResetThrow()
	{
		readyToThrow = true;
	}
	public void ResetThrowCount(int newTotalThrows)
	{
		totalThrows = newTotalThrows;
		UpdateThrowCountDisplay(); // Cập nhật hiển thị
	}
}