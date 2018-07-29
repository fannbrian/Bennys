using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bennys;

public class TableGui : MonoBehaviour {
   public PlayerController player;
    public PlayerInteract playerinteract;
    public GenerateMoney generate;
    public float chance;
    private PlayerMoney money;
    public Button button1, button2;

    Canvas gui;
    public event Action OnPrepareToHide = delegate { };

    void Start () {
        gui = GetComponent<Canvas>();
        Button button1interact = button1.GetComponent<Button>();
        Button button2interact = button2.GetComponent<Button>();
        button1interact.onClick.AddListener(OnClickHide);
        button2interact.onClick.AddListener(OnClickLoot);
        money = FindObjectOfType<PlayerMoney>();
        generate = GetComponent<GenerateMoney>();
       
       
    }
    private void Update()
    {
        if (PlayerManager.s.IsGrabbed)
        {
            gui.enabled = false;
        }
    }
    //when the hide button is clicked, begin the hiding process
    public void OnClickHide()
    {
        //to create the 1 second delay that is requested
        StartCoroutine(DelayHide());
        gui.enabled = false;

    }
    //when the loot button is clicked, begin looting table 
    public void OnClickLoot()
    {
        chance = generate.CalculateChance();
        gui.enabled = false;
        StartCoroutine(DelayLoot());

    }
    IEnumerator DelayHide()
    {
     
        yield return new WaitForSeconds(1f);
        if (!PlayerManager.s.IsGrabbed)
        {
            OnPrepareToHide();
        }
    }
    IEnumerator DelayLoot()
    {
        yield return new WaitForSeconds(1.5f);
        //     player.GetComponent<PlayerController>().enabled = true;
        if (!PlayerManager.s.IsGrabbed)
        {
            player.isinteracting = false;
            playerinteract.GetComponent<PlayerInteract>().enabled = true;
            if (chance <= 10 && chance > 5)
            {
                money.mcurrentMoney += generate.CalculateAmount(1, 2);
            }
            else if (chance <= 5)
            {
                money.mcurrentMoney += 3;
            }
        }
    }
}