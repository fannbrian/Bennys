using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHide : MonoBehaviour {
    private TableGui interaction;
    private ArcadeGUI arcade;
    public bool ishidden;
    private Collider2D collide;
    private SpriteRenderer render;
    private PlayerController playerfind;
    private PlayerInteract playerinteract;

    //Grab everything about the player, including the sprite renderer and collider
    void Start () {
        interaction = FindObjectOfType<TableGui>();
        arcade = FindObjectOfType<ArcadeGUI>();
        playerfind = interaction.player.GetComponent<PlayerController>();
        playerinteract = FindObjectOfType<PlayerInteract>();
        collide = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
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
        collide.enabled = false;
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
        collide.enabled = true;
        render.enabled = true;
        playerfind.enabled = true;
        playerinteract.enabled = true;
    }

}
