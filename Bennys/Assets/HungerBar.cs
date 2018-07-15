using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour { //This class changes the Text whenever the Hunger value is changed
    public Text text;
    public PlayerHunger player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerHunger>();
	}
	
	// Update is called once per frame
	void Update () { 
      text.text = "Hunger: " + player.Hunger.ToString(); 
	}
}
