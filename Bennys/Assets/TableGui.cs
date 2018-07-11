using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableGui : MonoBehaviour {
   public PlayerController player;
    Canvas gui;
	// Use this for initialization
	void Start () {
        gui = GetComponent<Canvas>();
	}
    public void Clicked()
    {
        Debug.Log("I've been clicked");
        player.GetComponent<PlayerController>().enabled = true;
        gui.enabled = false;
    }
}
