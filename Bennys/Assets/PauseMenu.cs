using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;  // public to be accessible from other scripts. static to be easily checked from other scripts. 

    public GameObject pauseButton; // Pause button clicked to pause game. Disappears once paused. Reappears when playing game. 

    public GameObject pauseMenuUI; // Pause Menu UI game object assigned in inspector

    public GameObject settingsPanelUI; // Options Menu UI game object assigned in inspector

	// Update is called once per frame
	void Update ()    
    {
		if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (GameIsPaused)   // if escape key is pressed and GameIsPaused == true, then game will resume .
            {
                Resume();
                pauseButton.SetActive(false);
            } 
            else   
            {
                Pause();
                pauseButton.SetActive(true);
            }
        }
	}

    public void Resume() // Pause UI set to inactive, time reset to 1, GameIsPaused set to false
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() // Pause UI set to active, time stopped, GameIsPaused set to true.
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Settings()
    {
        pauseMenuUI.SetActive(false);
        settingsPanelUI.SetActive(true);
    }

    public void BackToPause()
    {
        pauseMenuUI.SetActive(true);
        settingsPanelUI.SetActive(false);
    }

    public void LoadMenu() // If menu button is pressed, then load Main Menu scene
    {
        SceneManager.LoadScene( "Main Menu");
        Debug.Log("Loading menu... ");
    }

    public void QuitGame() // if Quit button is pressed, then close application
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
}
