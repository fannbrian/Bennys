
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : MonoBehaviour, IInteractable {
     public GameObject canvasObj;
     public PlayerController player;
     public PlayerInteract playerinteract;
    void Start () {
        canvasObj.GetComponent<Canvas>().enabled = false;
       player.GetComponent<PlayerController>().enabled = true;
        playerinteract.GetComponent<PlayerInteract>().enabled = true;
    }
    //OnInteraction main function for this object is to activate the menu for the player 
   public void OnInteraction()
    {
        player.GetComponent<PlayerController>().enabled = false;
        playerinteract.enabled = false;
        canvasObj.GetComponent<Canvas>().enabled = true;
    }
}
