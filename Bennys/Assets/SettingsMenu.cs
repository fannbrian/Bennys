using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
    /// <summary>
    /// Made by Peter Doria July 7, 2018
    /// Controls Music and SFX volume values. Toggles fullscreen.
    /// </summary>
    public AudioMixer audioMusic;

    public AudioMixer audioSound;

    [SerializeField]
    public float musicVolume;

    [SerializeField]
    public float soundVolume;

    public bool fullScreen = true;

    public void SetMusVolume(float musicVolume)
    {
        audioMusic.SetFloat("Music", musicVolume);
    }

    public void SetSoundVolume(float soundVolume)
    {
        audioSound.SetFloat("Sound", soundVolume);
    }

    public void ToggleFullscreen()
    {
        if (fullScreen == true)
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        else
        {
            Screen.fullScreen = Screen.fullScreen;
        }
    }
}
