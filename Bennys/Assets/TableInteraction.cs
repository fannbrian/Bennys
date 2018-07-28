
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bennys
{
    public class TableInteraction : MonoBehaviour, IInteractable
    {
        public GameObject canvasObj;
        public PlayerController player;
        public PlayerInteract playerinteract;
        void Start()
        {
            player = PlayerManager.s.player.GetComponent<PlayerController>();
            playerinteract = PlayerManager.s.player.GetComponent<PlayerInteract>();
            

            canvasObj.GetComponent<Canvas>().enabled = false;
            player.enabled = true;
            playerinteract.enabled = true;
        }
        //OnInteraction main function for this object is to activate the menu for the player 
        public void OnInteraction()
        {
            if (!PlayerManager.s.IsGrabbed)
            {
                player.GetComponent<PlayerController>().enabled = false;
                playerinteract.enabled = false;
                canvasObj.GetComponent<Canvas>().enabled = true;
            }
        }
    }
}