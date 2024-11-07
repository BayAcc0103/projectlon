using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    private Animator _animator;
    private bool _isOpen = false;
    public AudioSource _audioSource; // Thêm biến để lưu trữ AudioSource
    public AudioClip doorSound; // Reference to the sound effect


    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isOpen)
            {
                OpenDoor();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoorAfterDelay(3f)); // Đặt thời gian đóng cửa
        }
    }

    void OpenDoor()
    {
        _isOpen = true;
        _animator.SetBool("open", true);
        if (_audioSource != null && doorSound != null)
        {
            _audioSource.PlayOneShot(doorSound);
        }


    }

    
}
