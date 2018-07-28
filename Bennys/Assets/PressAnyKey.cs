using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour {
    Canvas canvas;
    Text text;

	void Start () {
        canvas = GetComponent<Canvas>();
        text = canvas.GetComponent<Text>();
        StartCoroutine(FlashingText());
    }
	
	//checks if the user presses and keys 
	void Update () {
      
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Level1");
        }
	}

    //Will infinitely blink the text
    IEnumerator FlashingText()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            canvas.enabled = false;
            yield return new WaitForSeconds(1f);
            canvas.enabled = true;
        }
    }
}
