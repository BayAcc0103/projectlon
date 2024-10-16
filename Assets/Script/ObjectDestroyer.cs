﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;// Thêm dòng này để sử dụng UI

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject objectToDestroy; // Đối tượng cần hủy
    private float holdTime = 0f; // Thời gian giữ phím E
    public Transform player;
    public float activationDistance = 3f;
    public float requiredHoldTime = 5f; // Thời gian yêu cầu để hủy đối tượng
    public GameManager gameManager; // Tham chiếu đến GameManager để xử lý game
    public TMP_Text holdTimeText; // Tham chiếu đến Text hiển thị thời gian giữ

    private void Update()
    {
        float distanceToObject = Vector3.Distance(player.position, objectToDestroy.transform.position);

        // Nếu người chơi ở trong khoảng cách yêu cầu
        if (distanceToObject <= activationDistance)
        {
            // Kiểm tra xem người chơi có giữ phím E không
            if (Input.GetKey(KeyCode.E))
            {
                holdTime += Time.deltaTime; // Tăng thời gian giữ theo thời gian thực

                // Cập nhật hiển thị thời gian giữ
                holdTimeText.text = "" + Mathf.Ceil(requiredHoldTime - holdTime).ToString() + "s";

                // Nếu người chơi giữ phím E đủ thời gian
                if (holdTime >= requiredHoldTime)
                {
                    DisableObject(); // Hủy đối tượng
                }
            }
            else
            {
                holdTime = 0f; // Reset lại thời gian giữ nếu nhả phím
                holdTimeText.text = ""; // Xóa hiển thị khi không giữ phím
            }
        }
        else
        {
            holdTimeText.text = ""; // Xóa hiển thị khi ra ngoài khoảng cách
        }
    }

    private void DisableObject()
    {
        objectToDestroy.SetActive(false); // Tắt đối tượng
        holdTimeText.text = "";
        // Gọi GameManager để hiển thị thông báo "Winner"
        gameManager.ShowWinnerText();
    }
}
