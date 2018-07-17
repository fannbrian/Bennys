using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuButtonLayoutUI;

    public GameObject quitPanelUI;

    public GameObject settingsPanelUI; // Options Menu UI game object assigned in inspector

    public int clickCount;

    public UnityEvent PleaseDontLeave;

    public void Play() // Pause UI set to inactive, time reset to 1, GameIsPaused set to false
    {
        SceneManager.LoadScene("Main");
        Debug.Log("Loading Intro...");
    }

    public void Settings()
    {
      
        settingsPanelUI.SetActive(true);
        mainMenuButtonLayoutUI.SetActive(false);
    }

    public void BackToMenuFromSettings()
    {
    
        settingsPanelUI.SetActive(false);
        mainMenuButtonLayoutUI.SetActive(true);
    }

    public void Credits() // If menu button is pressed, then load Main Menu scene
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Loading Credits... ");
    }

    public void QuitGamePanel() // if Quit button is pressed, then close application
    {
        quitPanelUI.SetActive(true);
        mainMenuButtonLayoutUI.SetActive(false);
    }

    public void QuitYes()
    {
    //    if (clickCount >= 6)
    //    {
            Application.Quit();
            Debug.Log("Quitting... ");
    //    }
    //    else
    //    {
    //        Debug.Log("Please Dont Leave... ");
    //        PleaseDontLeave.Invoke();
    //    }
        /// player needs to click Leave Benny's button 6 times to leave. After clicking once, everything starts 
        // to go black and change color      
       
    }

    public void BackToMenuFromQuitPanel()
    {
        quitPanelUI.SetActive(false);
        mainMenuButtonLayoutUI.SetActive(true);
    }
}

