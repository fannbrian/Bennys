using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("EXIT");
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}