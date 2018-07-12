using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : MonoBehaviour, IInteractable {
    public GameObject canvasObj;
   public PlayerController player;
	void Start () {
        canvasObj.GetComponent<Canvas>().enabled = false;
        player.GetComponent<PlayerController>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
    
	}
   public void OnInteraction()
    {
        Debug.Log("I'm a Table");
        canvasObj.GetComponent<Canvas>().enabled = true;
       player.GetComponent<PlayerController>().enabled = false;
    }
}
