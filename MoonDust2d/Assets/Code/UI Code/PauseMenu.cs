using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ 
    public GameObject pauseMenuUI;
    public Button resumeButton;
    private bool isPaused = false;
    public AudioSource _audioSource1;
    public AudioSource _audioSource2;
    private AudioSource _audioSourceSoul;
    public Slider Vslider;
    private SoundManager _soundManager;
    void Start()
    {
        // Hide the pause menu at the start of the game
        pauseMenuUI.SetActive(false);
        _audioSourceSoul = GameObject.Find("Soul").GetComponent<AudioSource>();
        _soundManager = GetComponent<SoundManager>();
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
        _soundManager.Click();
        TogglePauseMenu();
    }

    public void QuitGame()
    {
        _soundManager.Click();
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
    public void AudioGlobal()
    {
        AudioListener.volume = Vslider.value;
        Save();
    }

    void start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }
        else
        {
            Load();
        }
    }
    private void Load()
    {
        Vslider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", Vslider.value);
    }

    public void ReturnToMenu()
    {
        StartCoroutine(MainDelay());
        
    }
    public IEnumerator MainDelay()
    {
        _soundManager.Click();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainMenu");
    }
}
