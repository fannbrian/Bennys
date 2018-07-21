using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Bennys
{
    public class PlayerHide : MonoBehaviour
    {
        public static PlayerHide s;
        private TableGui interaction;
        private ArcadeGUI arcade;
        public bool ishidden;
        private PlayerController playerfind;
        private PlayerInteract playerinteract;
        public SpriteRenderer render;

        //Grab everything about the player, including the sprite renderer and collider
        void Start()
        {
            s = this;
            interaction = FindObjectOfType<TableGui>();
            arcade = FindObjectOfType<ArcadeGUI>();
            playerfind = PlayerManager.s.player.GetComponent<PlayerController>();
            playerinteract = FindObjectOfType<PlayerInteract>();
            arcade.OnPrepareToHide += HandleHide;
            interaction.OnPrepareToHide += HandleHide;
        }
        void Update()
        {
            //Check if the player wants to opt out of hiding
            if (ishidden && Input.GetKeyDown(KeyCode.Space))
            {
                HandleUnhide();
            }
        }
        //This sets the necessary components inactive to simulate "hiding"
        void HandleHide()
        {
            ishidden = true;
            render.enabled = false;
        }
        //turns the previously deactivated components back on after 0.5 second delay
        void HandleUnhide()
        {
            StartCoroutine(UnHideDelay());
        }
        IEnumerator UnHideDelay()
        {
            yield return new WaitForSeconds(0.5f);
            ishidden = false;
            render.enabled = true;
            playerfind.enabled = true;
            playerinteract.enabled = true;
        }
        public void UnHideImmediate()
        {
            ishidden = false;
            render.enabled = true;
            playerfind.enabled = true;
            playerinteract.enabled = true;
        }
    }
}