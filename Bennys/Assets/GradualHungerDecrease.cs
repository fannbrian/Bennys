using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradualHungerDecrease : MonoBehaviour {
    public PlayerHunger hunger;
            PlayerMoney money;
    float seconds;
	// Use this for initialization
	void Start () {
        hunger = FindObjectOfType<PlayerHunger>();
        money = FindObjectOfType<PlayerMoney>();
	}
	
	// Update is called once per frame
	void Update () {

        seconds += Time.deltaTime;
        if(seconds > 2.0f && money.Money > 0)
        {
            hunger.Hunger--;
            seconds = 0;
        }

	}

}
