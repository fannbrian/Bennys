using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Bennys;

public class ArcadeGUI : MonoBehaviour {
    public PlayerController player;
    public PlayerInteract playerinteract;
    public PlayerMoney money;
    private GenerateMoney generate;
    public float chance;
    public Button button1, button2;
    Canvas gui;
    public event Action OnPrepareToHide = delegate { };

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerinteract = FindObjectOfType<PlayerInteract>();
        gui = GetComponent<Canvas>();
        Button button1interact = button1.GetComponent<Button>();
        Button button2interact = button2.GetComponent<Button>();
        button1interact.onClick.AddListener(OnClickPlay);
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
    public void OnClickPlay()
    {
        //to create the 1 second delay that is requested
        StartCoroutine(DelayHide());
        gui.enabled = false;
        money.mcurrentMoney -= 3;
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
        if (!PlayerManager.s.IsGrabbed)
        {
            player.isinteracting = false;
            playerinteract.GetComponent<PlayerInteract>().enabled = true;
            if (chance <= 20)
            {
                money.mcurrentMoney += generate.CalculateAmount(2, 5);
            }
        }
    }
}
