using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Transitiontolevel1());
	}
    IEnumerator Transitiontolevel1()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Level1");
    }
}
