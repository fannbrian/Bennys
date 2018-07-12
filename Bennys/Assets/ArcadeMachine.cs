using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour,IInteractable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void OnInteraction()
    {
        Debug.Log("I'm an arcade machine");
    }
}
