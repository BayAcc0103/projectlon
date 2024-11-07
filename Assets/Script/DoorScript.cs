using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    private Animator _animator;
    private bool _isOpen = false;
    public AudioSource _audioSource; // Thêm biến để lưu trữ AudioSource
    public AudioClip doorSound; // Reference to the sound effect


    

    void OpenDoor()
    {
        _isOpen = true;
        _animator.SetBool("open", true);
        if (_audioSource != null && doorSound != null)
        {
            _audioSource.PlayOneShot(doorSound);
        }


    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isOpen = false;
        _animator.SetBool("open", false);
    }
}
