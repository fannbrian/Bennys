using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bennys;

public class ServerControlSpeech : MonoBehaviour {
    public ServerSpeechBubble speechbubble;
    public Canvas canvas;
    bool istalking = false;
	// Use this for initialization
	void Start () {
        speechbubble = FindObjectOfType<ServerSpeechBubble>();
        canvas = speechbubble.GetComponentInParent<Canvas>();
        canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerManager.s.IsGrabbed && !istalking)
        {
            istalking = true;
            canvas.enabled = true;
            StartCoroutine(Talk());
          
            
            
        }

	}
    IEnumerator Talk()
    {
        if (PlayerManager.s.IsGrabbed)
        {
            yield return new WaitForSeconds(2f);
            speechbubble.Generatespeech();
        }
        canvas.enabled = false;
        istalking = false;
    }
}
