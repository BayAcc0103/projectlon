using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Countdown timer fields
    public TMP_Text timerText; // Assign this in the inspector
    public TMP_Text loseText;
    public TMP_Text winnerText; // Tham chiếu đến TMP Text để hiển thị thông báo "Winner"
    public TMP_Text terroristText;
    public TMP_Text counterTerroristText;
    public float timeRemaining = 300; // Thời gian đếm ngược
    public float timeReset = 300;
    private bool isRunning = true;
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip loseSound; // Reference to the sound effect
    public AudioClip winSound;

    // Game objects management
    public GameObject[] gameObjectsToManage; // Array of game objects to manage
    private Vector3[] initialPositions; // Array to store initial positions

    // Throwing tutorial fields
    public ThrowingTutorial throwingTutorial;
    public int initialThrowCount = 90;
    public float winnerTextDisplayTime = 5f; // Thời gian hiển thị thông báo "Winner"

    private bool gameEnded = false;
    private int terroristsScore = 0; // Điểm của bên Terrorists
    private int counterTerroristsScore = 0; // Điểm của bên Counter Terrorists

    private void Start()
    {
        // Lưu trữ vị trí ban đầu của các đối tượng
        initialPositions = new Vector3[gameObjectsToManage.Length];
        for (int i = 0; i < gameObjectsToManage.Length; i++)
        {
            initialPositions[i] = gameObjectsToManage[i].transform.position;
        }
    }

    private void Update()
    {
        if (isRunning && !gameEnded)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                TimerEnded();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Phương thức khi hết giờ, hiện loseText và reset sau 5 giây
    void TimerEnded()
    {
        loseText.text = "Terrorists Win!";
        if (audioSource != null && loseSound != null)
        {
            audioSource.PlayOneShot(loseSound);
        }
        timerText.gameObject.SetActive(false);

        // Đánh dấu là game đã kết thúc
        gameEnded = true;

        terroristsScore++;
        terroristText.text = terroristsScore + "  Terrorist";

        // Gọi Reset sau 5 giây
        StartCoroutine(ResetAfterDelay());
    }

    // Phương thức hiển thị WinnerText khi DestroyObject được gọi và reset sau 5 giây
    public void ShowWinnerText()
    {
        if (gameEnded) return; // Nếu game đã kết thúc, không làm gì cả
        winnerText.gameObject.SetActive(true);
        winnerText.text = "Counter Terrorists Win!";

        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
        // Đánh dấu là game đã kết thúc
        gameEnded = true;

        counterTerroristsScore++;
        counterTerroristText.text = "Counter-Terrorist  " + counterTerroristsScore;
        // Gọi Reset sau 5 giây
        StartCoroutine(ResetAfterDelay());
    }

    // Phương thức reset game chung, gọi sau một delay
    private IEnumerator ResetAfterDelay()
    {
        // Delay 5 giây
        yield return new WaitForSeconds(5f);

        // Reset timer và game objects
        ResetGame();
    }

    // Reset tất cả sau khi delay
    public void ResetGame()
    {
        ResetTimer();

        // Reset the state of managed game objects
        for (int i = 0; i < gameObjectsToManage.Length; i++)
        {
            // Đặt lại vị trí của từng đối tượng
            gameObjectsToManage[i].transform.position = initialPositions[i];
            gameObjectsToManage[i].SetActive(true); // Bật đối tượng (có thể điều chỉnh)
        }

        // Reset throw count
        throwingTutorial.ResetThrowCount(initialThrowCount);

        // Ẩn thông báo sau khi reset
        winnerText.gameObject.SetActive(false);
        loseText.text = "";

        // Đánh dấu là game chưa kết thúc
        gameEnded = false; // Đặt lại trạng thái game
    }

    public void ResetTimer()
    {
        timeRemaining = timeReset; // Reset to initial time
        isRunning = true; // Restart the timer
        timerText.gameObject.SetActive(true);
        loseText.text = "";
        UpdateTimerText(); // Update the display
    }
}
