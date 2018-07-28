using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningCanvas : MonoBehaviour {
    public Image text1,text2,text3,text4,text5;
    // Use this for initialization
    WaitForSeconds wait;
	void Start () {
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
        text5.enabled = false;
        wait = new WaitForSeconds(5f);
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Transitiontolevel1());
	}
    IEnumerator Transitiontolevel1()
    {
        yield return new WaitForSeconds(1f);
        text1.enabled = true;
        yield return wait;
        text2.enabled = true;
        yield return wait;
        text3.enabled = true;
        yield return wait;
        text4.enabled = true;
        yield return wait;
        text5.enabled = true;
        yield return wait;
        SceneManager.LoadScene("Level1");
    }
}
