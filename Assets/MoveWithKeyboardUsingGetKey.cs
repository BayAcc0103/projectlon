using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKeyboardUsingGetKey : MonoBehaviour
{
    public float moveSpeed = 200f; // Tốc độ di chuyển
    public float turnSpeed = 200f; // Tốc độ quay
    void Update()
    {
        Vector3 movement = Vector3.zero;
        float turn = 0f;
        // Sử dụng các phím W, A, S, D hoặc phím mũi tên để di chuyển
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.forward; // Di chuyển lên phía trước
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.back; // Di chuyển về phía sau
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
       
            movement += Vector3.left; // Di chuyển sang trái
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            movement += Vector3.right; // Di chuyển sang phải
        }

        // Di chuyển vật thể dựa trên input từ bàn phím
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        // Xử lý quay trái/phải chỉ khi nhấn Q hoặc E
        if (Input.GetKey(KeyCode.Q)) // Quay trái
        {
            turn = -1f; // Quay sang trái
        }
        if (Input.GetKey(KeyCode.E)) // Quay phải
        {
            turn = 1f; // Quay sang phải
        }
        // Quay xe dựa trên input từ bàn phím
        if (turn != 0f)
        {
            transform.Rotate(0f, turn * turnSpeed * Time.deltaTime, 0f, Space.World);
        }
    }
}
