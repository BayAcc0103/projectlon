using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartMenu : MonoBehaviour
{
    private MenuInput controls;

    private void Awake()
    {
        // Initialize the controls
        controls = new MenuInput();

        // Set up listeners for gamepad actions
        controls.MenuButton.StartButton.performed += ctx => StartGame();
        controls.MenuButton.PauseButton.performed += ctx => PauseGame();
        controls.MenuButton.EndButton.performed += ctx => QuitGame();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void StartGame()
    {
        // Load the main game scene (replace "MainGame" with your actual scene name)
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
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
