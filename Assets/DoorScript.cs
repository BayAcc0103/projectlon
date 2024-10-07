using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    private Animator _animator;
    private bool _isOpen = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if (!_isOpen)
            {
                OpenDoor();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            StartCoroutine(CloseDoorAfterDelay(3f)); // Đặt thời gian đóng cửa
        }
    }

    void OpenDoor()
    {
        _isOpen = true;
        _animator.SetBool("open", true);
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isOpen = false;
        _animator.SetBool("open", false);
    }
}
