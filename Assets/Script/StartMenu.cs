using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        // Load the main game scene (make sure to replace "MainGame" with your actual scene name)
        SceneManager.LoadScene("projectlon");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void PauseGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
