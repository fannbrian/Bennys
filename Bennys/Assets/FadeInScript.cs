using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour {
    CanvasGroup canvasgroup;
	// Use this for initialization
	void Start () {
        canvasgroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn());
        
	}
	IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        while(canvasgroup.alpha > 0)
        {
            canvasgroup.alpha -= Time.deltaTime/2;
        }
    }
}
