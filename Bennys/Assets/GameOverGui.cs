using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverGui : MonoBehaviour {
    public Button button1, button2;
    Scene scene;
    // Use this for initialization
    void Start () {
        Button button1interact = button1.GetComponent<Button>();
        Button button2interact = button2.GetComponent<Button>();
        button1interact.onClick.AddListener(OnClickRetry);
        button2interact.onClick.AddListener(OnClickMainMenu);
        scene = SceneManager.GetActiveScene();


    }
	
    void OnClickRetry()
    {
        SceneManager.LoadScene(scene.name);
    }
    void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
