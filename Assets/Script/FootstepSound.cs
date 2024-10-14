using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [Header("Footstep Audio")]
    public AudioSource footstepSource; // AudioSource to play footstep sounds

    public AudioClip grassClip;
    public AudioClip metalClip;
    public AudioClip roadClip;

    [Header("Settings")]
    public float footstepDelay = 0.5f; // Time between footsteps
    private float footstepTimer;

    private PlayerMovementAdvanced playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementAdvanced>();
        footstepTimer = 0;
    }

    private void Update()
    {
        // Only play footstep sounds if the player is moving
        if (playerMovement.grounded && playerMovement.moveDirection.magnitude > 0.1f)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0)
            {
                PlayFootstepSound();
                footstepTimer = footstepDelay; // Reset footstep timer
            }
        }
    }

    private void PlayFootstepSound()
    {
        // Raycast to check what terrain the player is standing on
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, playerMovement.playerHeight * 0.5f + 0.3f))
        {
            // Check the tag of the surface hit by the raycast and play corresponding sound
            string hitTag = hit.collider.gameObject.tag;

            if (hitTag == "Grass")
            {
                footstepSource.PlayOneShot(grassClip);
            }
            else if (hitTag == "Metal")
            {
                footstepSource.PlayOneShot(metalClip);
            }
            else if (hitTag == "Road")
            {
                footstepSource.PlayOneShot(roadClip);
            }
        }
    }
}
