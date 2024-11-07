using UnityEngine;
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
	public bool alive = true;	
	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	

	private void DisableObject()
	{	
		alive = false;
		objectToDestroy.SetActive(false); // Tắt đối tượng
		holdTimeText.text = "";
		// Gọi GameManager để hiển thị thông báo "Winner"
		//gameManager.EndGame(true);
		gameManager.isWin = true;
		gameManager.EndGame();
	}
}
