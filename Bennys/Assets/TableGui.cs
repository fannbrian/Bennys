using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableGui : MonoBehaviour {
   public PlayerController player;
    public PlayerInteract playerinteract;
    public Button button1, button2; 
    Canvas gui;
    public event Action OnPrepareToHide = delegate { };

    void Start () {
        gui = GetComponent<Canvas>();
        Button button1interact = button1.GetComponent<Button>();
        Button button2interact = button2.GetComponent<Button>();
        button1interact.onClick.AddListener(OnClickHide);
        button2interact.onClick.AddListener(OnClickLoot);
    }
    //when the hide button is clicked, begin the hiding process
    public void OnClickHide()
    {
        
       // Debug.Log("I've been clicked");
        //to create the 1 second delay that is requested
        StartCoroutine(DelayHide());
        gui.enabled = false;

    }
    //when the loot button is clicked, begin looting table 
    public void OnClickLoot()
    {
        Debug.Log("Looting Table");
        player.GetComponent<PlayerController>().enabled = true;
        playerinteract.GetComponent<PlayerInteract>().enabled = true;
        gui.enabled = false;
    }
    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(1f);
        OnPrepareToHide();
    }
}
