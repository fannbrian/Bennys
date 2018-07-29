using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuButtonLayoutUI;

    public GameObject quitPanelUI;

    public GameObject settingsPanelUI; // Options Menu UI game object assigned in inspector

    public GameObject settingsBG; // BG for settings Menu

    public GameObject eatAtBennysArrow; 

    public int clickCount;

    public UnityEvent PleaseDontLeave;

    public void Play() // Pause UI set to inactive, time reset to 1, GameIsPaused set to false
    {
        SceneManager.LoadScene("Opening");
        Debug.Log("Loading Intro...");
    }

    public void Settings()
    {
      
        settingsPanelUI.SetActive(true);
        settingsBG.SetActive(true);

        mainMenuButtonLayoutUI.SetActive(false);
        eatAtBennysArrow.SetActive(false);
    }

    public void BackToMenuFromSettings()
    {
        settingsPanelUI.SetActive(false);
        settingsBG.SetActive(false);

        mainMenuButtonLayoutUI.SetActive(true);
        eatAtBennysArrow.SetActive(true);
    }

    public void Credits() // If menu button is pressed, then load Main Menu scene
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Loading Credits... ");
    }

    public void QuitGamePanel() // if Quit button is pressed, then close application
    {
        quitPanelUI.SetActive(true);
        settingsBG.SetActive(true);

        mainMenuButtonLayoutUI.SetActive(false);
        eatAtBennysArrow.SetActive(false);
    }

    public void QuitYes()
    {
            Application.Quit();
            Debug.Log("Quitting... ");       
    }

    public void BackToMenuFromQuitPanel()
    {
        quitPanelUI.SetActive(false);
        settingsBG.SetActive(false);

        mainMenuButtonLayoutUI.SetActive(true);
        eatAtBennysArrow.SetActive(true);
    }
}

