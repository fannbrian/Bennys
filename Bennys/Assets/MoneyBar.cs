using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour {
    public Text text;
    public PlayerMoney player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Money: " + player.mcurrentMoney.ToString();
    }
}
