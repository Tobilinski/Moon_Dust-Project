using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{ 
    public GameObject pauseMenuUI;
    public Button resumeButton;
    private bool isPaused = false;
    private AudioSource _audioSource;
    void Start()
    {
        // Hide the pause menu at the start of the game
        pauseMenuUI.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
    }
    

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            pauseMenuUI.SetActive(true);
            resumeButton.Select();
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            pauseMenuUI.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void ResumeGame()
    {
        TogglePauseMenu();
    }

    public void QuitGame()
    {
        Application.Quit();// Quit the game
        print("Quit");
    }

    public void PauseButtonInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            TogglePauseMenu();
        }
    }
    public void SetSoundVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
