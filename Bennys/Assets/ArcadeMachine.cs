using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour,IInteractable {
    PlayerMoney money;
    public GameObject canvasObj;
    private PlayerController player;
    private PlayerInteract playerinteract;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        playerinteract = FindObjectOfType<PlayerInteract>();
        canvasObj.GetComponent<Canvas>().enabled = false;
    }
	
   public void OnInteraction()
    {
        player.GetComponent<PlayerController>().enabled = false;
        playerinteract.enabled = false;
        canvasObj.GetComponent<Canvas>().enabled = true;
    }
}
