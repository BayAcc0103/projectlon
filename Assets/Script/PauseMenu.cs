using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public GameObject pauseMenuUI; // Reference to the pause menu UI

    private void Start()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu initially
    }

    private void Update()
    {
        // Check if the player presses the pause key (e.g., Escape)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0; // Freeze the game
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1; // Resume the game
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Game is quitting");
    }
}